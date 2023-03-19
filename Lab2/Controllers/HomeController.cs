using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
using Lab2.Data;

namespace Lab2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext _db;
    public HomeController(ILogger<HomeController> logger,
        ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Seed()
    {
        _db.Catalogs.AddRange( 
            new CatalogModel() { Id = 1, Title = "AGD" },
            new CatalogModel() { Id = 2, Title = "Zabawki" }
        );
        _db.Products.AddRange(
            new ProductModel() { Id = 1, Title = "Lodówka", Description = "Chłodzi", CatalogId = 1 },
            new ProductModel() { Id = 2, Title = "Piekarnik", Description = "Grzeje", CatalogId = 1 },
            new ProductModel() { Id = 3, Title = "Samochodzik", Description = "Metalowy", CatalogId = 2 }
        );
        _db.SaveChanges();
        return RedirectToAction("index");
    }

    public IActionResult Index()
    {
        var cat = _db.Catalogs.FirstOrDefault();
        ViewBag.prod = _db.Products;
        return View(cat);
    }

    public IActionResult Search(string q)
    {
        var cat = _db.Catalogs.FirstOrDefault();
        ViewBag.prod = _db.Products.Where(c=>c.Title == q);
        return View("Index", cat);
    }

    public IActionResult Get(string q)
    {
        var res = _db.Products
            .Where(s=>s.Title==q)
            .Select(t=>new PoductViewModel(){Id=t.Id, Title=t.Title, 
                Catalog=t.Catalog.Title});
        return Json(res);
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
