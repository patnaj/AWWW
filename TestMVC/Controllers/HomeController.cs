﻿using System.Diagnostics;
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
        return Json( 
        // Db.GetMarksList(null)
            Db.GetStudentList()
        );

        return View();
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
