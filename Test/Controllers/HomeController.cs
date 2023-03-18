using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    Test.Data.ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, Test.Data.ApplicationDbContext db)
    {
        _db = db;
        _logger = logger;
    }

    public IActionResult Index()
    {
        // ViewBag.catalog = _db.Catalogs.FirstOrDefault();
        return View(_db.Products.ToList());
    }

    public IActionResult Seed(){
        try{
        if( _db.Products.Count() == 0){
            var c = new CatalogModel(){Title="Cat"};
            _db.Catalogs.Add(c);
            _db.Products.AddRange(
                new ProductModel(){Title="Test1", Desc="ss", Catalog = c},
                new ProductModel(){Title="Test2", Desc="ss", Catalog = c}
            );
            _db.SaveChanges();
        }
        }catch(Exception e){
            return Content(e.Message);
        }
        return RedirectToAction("index");
        // return RedirectToAction("index", new {controller="Itt", abc=1});
        // return Redirect(Url.Action("Index")));
    }

    public IActionResult Del(int id)
    {
        var s = _db.Products.Where(d => d.Id == id).ToList();
        if(s.Count() > 0){
            _db.Products.Remove(s[0]);
            _db.SaveChanges();
        }
        return RedirectToAction("index");
    }

    [HttpGet]
    public IActionResult Edit(int id){
        var s = _db.Products.Where(d => d.Id == id).ToList();
        if(s.Count()== 0)
            return RedirectToAction("index");
        return View(s[0]);
    }

    [HttpPost]
    public IActionResult Edit(int id, ProductModel p){
        var s = _db.Products.Where(d => d.Id == id).FirstOrDefault();
        if(s != null){
            s.Title = p.Title;
            // _db.Products.Update(p);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        return View(s);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
