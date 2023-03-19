using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lab1.Controllers
{
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;
        
        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            var data = Models.CarModel.Data();

            if(id!=0)
                data = data.Where(i =>i.Id == id).ToList();

            var res = "";
            foreach(var c in data)
                res += $"<a href=/car/index/{c.Id}>{c.RegNum}</a> <a href={Url.Action("Index", "Owner", new {car_id = c.Id, return_to_id=id==c.Id})}> owners</a><br>";
            return this.Content(res, "text/html");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}

