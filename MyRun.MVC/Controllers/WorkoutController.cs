using Microsoft.AspNetCore.Mvc;

namespace MyRun.MVC.Controllers
{
    public class WorkoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
