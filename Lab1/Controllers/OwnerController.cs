using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class OwnerController : Controller
    {
        private readonly ILogger<OwnerController> _logger;
        
        public OwnerController(ILogger<OwnerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id, int car_id, bool return_to_id)
        {
            var data = Models.OwnerModel.Data();

            if(id!=0)
                data = data.Where(i =>i.Id == id).ToList();
            if(car_id!=0)
                data = data.Where(i =>i.IdCar == car_id).ToList();

            var res = "";
            foreach(var c in data)
                res += $"{c.Id}{c.Name}<br>";
            res += $"<a href={(return_to_id ? Url.Action("Index", "Car", new {id=car_id}) : Url.Action("Index", "Car"))}> back</a>";
            return this.Content(res, "text/html");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}

