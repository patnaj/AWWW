using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public TestMVC.Services.IStudentDbApi Db { get; }
    private readonly UserManager<Student> usersmgt;
    private readonly RoleManager<IdentityRole> rolemgt;

    public HomeController(ILogger<HomeController> logger, TestMVC.Services.IStudentDbApi db, UserManager<Student> usersmgt, RoleManager<IdentityRole> rolemgt)
    {
        this.rolemgt = rolemgt;
        this.usersmgt = usersmgt;
        this.Db = db;
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.teacher = User.IsInRole("teacher");
        ViewBag.user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (ViewBag.teacher)
            return View("student_index", Db.GetStudentList());
        return View();
    }

    public IActionResult AddRole(bool remove = false)
    {
        var Check = async () =>
        {
            var userTask = usersmgt.GetUserAsync(User);
            if (!await rolemgt.RoleExistsAsync("teacher"))
            {
                await rolemgt.CreateAsync(new IdentityRole("teacher"));
            }
            var user = await userTask;
            if (user != null)
            {
                // if(remove && await usersmgt.IsInRoleAsync(user, "teacher"))
                if (remove)
                    await usersmgt.RemoveFromRoleAsync(user, "teacher");
                else if (!remove)
                    await usersmgt.AddToRoleAsync(user, "teacher");
            }
        };
        Check().Wait();

        return Redirect("/Identity/Account/Logout");
    }

    public IActionResult Marks(string id)
    {
        ViewBag.teacher = User.IsInRole("teacher");
        if (!ViewBag.teacher) // tylko wglad w moje knto 
            id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var stud = Db.GetStudent(id);
        ViewBag.stud = stud?.Email;
        ViewBag.stud_id = stud?.Id;
        return View("mark_index", Db.GetMarksList(id));
    }

    [Authorize(Roles = "teacher")]
    [HttpGet]
    public IActionResult marks_remove(int id)
    {
        return View("confirm");
    }

    [Authorize(Roles = "teacher")]
    [HttpPost]
    public IActionResult marks_remove(int id, bool ok = true)
    {
        var s = Db.GetMarksList(null, i => i.Id == id).FirstOrDefault();
        if (s != null)
            Db.Delete(s);
        return RedirectToAction("marks", new { id = s?.StudentId });
    }

    [Authorize(Roles = "teacher")]
    [HttpGet]
    public IActionResult marks_add(string stud_id)
    {
        ViewBag.stud_id = stud_id;
        return View("mark_add", new Mark() { Date = DateTime.Now });
    }

    [Authorize(Roles = "teacher")]
    [HttpPost]
    public IActionResult marks_add(string stud_id, Mark mark)
    {
        ViewBag.stud_id = stud_id;
        if (!ModelState.IsValid)
            return View("mark_add", mark);

        mark.StudentId = stud_id;
        Db.AddMark(mark);
        return RedirectToAction("marks", new { id = stud_id });
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
