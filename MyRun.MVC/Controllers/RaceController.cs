using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRun.Application.Race;
using MyRun.Application.Race.Commands.CreateRace;
using MyRun.Application.Race.Commands.DeleteRace;
using MyRun.Application.Race.Commands.EditRace;
using MyRun.Application.Race.Queries.GetAllRaces;
using MyRun.Application.Race.Queries.GetRaceDetails;
using MyRun.Domain.Interfaces;

namespace MyRun.MVC.Controllers
{
    public class RaceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RaceController(IMediator mediatr, IMapper mapper)
        {
            _mediator = mediatr;
            _mapper = mapper;
        }

        //GET ALL
        public async Task<IActionResult> Index()
        {
            var races = await _mediator.Send(new GetAllRacesQuery());
            return View(races);
        }
        //GET ALL

        //GET DETAILS
        [Route("Race/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _mediator.Send(new GetRaceDetailsQuery(id));
            return View(dto);
        }
        //GET DETAILS

        //CREATE
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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

        //EDIT
        [Route("Race/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _mediator.Send(new GetRaceDetailsQuery(id));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditRaceCommand model = _mapper.Map<EditRaceCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Route("Race/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditRaceCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        //EDIT

        //DELETE
        [Route("Race/{id}/Delete")]
        public async Task<IActionResult> Delete(DeleteRaceCommand commnad)
        {
            var race = await _mediator.Send(commnad);
            return RedirectToAction(nameof(Index));
        }
        //DELETE
    }
        
}
