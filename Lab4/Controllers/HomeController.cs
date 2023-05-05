using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab4.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Lab4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles="manager")]
    public IActionResult Privacy()
    {
        ViewBag.userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
