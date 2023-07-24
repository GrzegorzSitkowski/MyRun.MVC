using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyRun.Application.Workout.Commands.CreateWorkout;
using MyRun.Application.Workout.Queries.GetAllWorkouts;

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
        
        //GET ALL
        public async Task<IActionResult> Index()
        {
            var workouts = await _mediator.Send(new GetAllWorkoutsQuery);
            return View(workouts);
        }
        //GET ALL

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
            return RedirectToAction(nameof(Index));
        }
        //CREATE
    }
}
