using Microsoft.AspNetCore.Mvc;

namespace MyRun.MVC.Controllers
{
    public class RaceController : Controller
    {
        [HttpPost]
        public IActionResult Create(Domain.Entities.Race race)
        {
            return View();
        }
    }
}
