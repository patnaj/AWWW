using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab1.Models;

namespace Lab1.Controllers;

public class AModel{
    public int A { get; set; }
    public int B { get; set; }
    public int id { get; set; }
}

public class ABC{
    public int A { get; set; }
    public int B { get; set; }

    // public string delete_url {get => $"<a href=/Home/delete/{A}> delete</a>";}
    
    public string delete_url {get => $"<a href=/Home/delete/{A}> delete</a>";}
}


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    List<ABC> list;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

        var s = new {ol=1};
        list = new List<ABC>(){
            new ABC(){A=1},new ABC{A=3}
        };

    }

    public IActionResult Index()
    {
        
        var i = @"\n";
        var s = $"cxcx {i}";
        
        return View();
    }

    public IActionResult lista()
    {
        var s = String.Concat(this.list.Select(a=>a.delete_url));
        return this.Content($"<html>{s}</html>", @"text/html");
        // return this.Content(@"<html><a href=/Home/Index> tetet</a></html>", @"text/html" );
    }

    public IActionResult delete(int id)
    {
        list.RemoveAll(a=>a.A==id);
        return this.Redirect( Url.Action("lista",new {controller="Home", id=1}));
    }


    public IActionResult Test2A()
    {
        // return this.Content(@"<html><a href=/Home/Index> tetet</a></html>" );
        return this.Content($"<html>{Url.Link("test", new {id=1})}<br/>{Url.Link("default2", new {id=1})}</html>" );
    }


    public IActionResult Test2(int a, string b)
    {
        if(a==3)
            return this.Redirect("/home/test3?id=1");
        if(a==2)
            return this.Content($"<html><a href=/Home/Test3>test3</a></html>", @"text/html" );
        return this.Content($"<html><a href=/Home/Index>{a},{b} tetet</a></html>", @"text/html" );
    }

    public IActionResult Test3(ABC b, int? id)
    {
        return this.Content($"<html><a href=/Home/Index>{b.A},{b.B}, {id} tetet</a></html>", @"text/html" );
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
