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

    [HttpGet]
    public IActionResult marks_remove(int id)
    {
        return View("confirm");
    }

    [HttpPost]
    public IActionResult marks_remove(int id, bool ok = true)
    {
        var s = Db.GetMarksList(null, i=>i.Id == id).FirstOrDefault();
        if(s != null)
            Db.Delete(s);
        return RedirectToAction("marks", new {id=s?.StudentId});
    }

    [HttpGet]
    public IActionResult marks_add(string stud_id)
    {
        ViewBag.stud_id = stud_id;
        return View("mark_add", new Mark(){Date=DateTime.Now});
    }

    [HttpPost]
    public IActionResult marks_add(string stud_id, Mark mark)
    {
        ViewBag.stud_id = stud_id;
        if(!ModelState.IsValid)
            return View("mark_add", mark);
        
        mark.StudentId = stud_id;
        Db.AddMark(mark);
        return RedirectToAction("marks", new {id=stud_id});
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
