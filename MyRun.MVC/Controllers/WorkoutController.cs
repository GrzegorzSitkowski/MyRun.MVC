using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyRun.Application.Workout.Commands.CreateWorkout;

namespace MyRun.MVC.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WorkoutController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkoutCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Create));
        }
        //CREATE
    }
}
