using Microsoft.AspNetCore.Mvc;
using MyRun.Application.Race;
using MyRun.Application.Services;
using MyRun.Domain.Interfaces;

namespace MyRun.MVC.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceService _raceService;

        public RaceController(IRaceService raceService)
        {
            _raceService = raceService;
        }

        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RaceDto race)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _raceService.Create(race);
            return RedirectToAction(nameof(Create));
        }
        //CREATE
    }
}
