using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRun.Application.Race;
using MyRun.Application.Race.Commands.CreateRace;
using MyRun.Application.Race.Queries.GetAllRaces;
using MyRun.Domain.Interfaces;

namespace MyRun.MVC.Controllers
{
    public class RaceController : Controller
    {
        private readonly IMediator _mediator;

        public RaceController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        //GET ALL
        public async Task<IActionResult> Index()
        {
            var races = await _mediator.Send(new GetAllRacesQuery());
            return View(races);
        }
        //GET ALL

        //GET ONE
        public IActionResult Details(int id)
        {
            return View();
        }
        //GET ONE

        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRaceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        //CREATE
    }
        
}
