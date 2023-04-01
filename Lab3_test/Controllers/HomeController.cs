using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab3_test.Models;
using Lab3_test.Services;
using Lab3_test.Data;

namespace Lab3_test.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


    private readonly Lab3_test.Services.ITimeServie it;
    private readonly IPersonService serv;

    public HomeController(ILogger<HomeController> logger, ITimeServie it, IPersonService serv, ApplicationDbContext db)
    {
        this.it = it;
        this.serv = serv;
        _logger = logger;
    }

    public IActionResult Index()
    {
        // serv.getFirst();
        serv.getList(a=>a.Name == "A");
        return View();
    }

    [HttpGet]
    public IActionResult Person()
    {
        ViewBag.fun = it.fun1(12);
        return View(new PersonModelView());
    }


    [HttpPost]
    public IActionResult Person(PersonModelView person)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("index");
        }
        return View(person);
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
