using Microsoft.AspNetCore.Mvc;

namespace MyRun.MVC.Controllers
{
    public class RunnerProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
