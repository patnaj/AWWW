using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab3.Models;
using Lab3.Services;

namespace Lab3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
        public IDataService Data { get; }

    public HomeController(ILogger<HomeController> logger, IDataService data)
    {
            this.Data = data;
        _logger = logger;
    }

    public IActionResult Index()
    {
        // return View();
        return this.Content(this.Data.getTime);
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
