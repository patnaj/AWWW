using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
        public TestMVC.Services.IStudentDbApi Db { get; }

    public HomeController(ILogger<HomeController> logger, TestMVC.Services.IStudentDbApi db)
    {
            this.Db = db;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("student_index",Db.GetStudentList());
    }

    public IActionResult Marks(string id)
    {
        // return Json(Db.GetMarksList(id));
        var stud = Db.GetStudent(id);
        ViewBag.stud = stud?.Email;
        ViewBag.stud_id = stud?.Id;
        return View("mark_index",Db.GetMarksList(id));
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
