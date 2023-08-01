using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRun.Application.RunnerProfile.Commands.CreateRunnerProfile;
using MyRun.Application.RunnerProfile.Query.GetRunnerProfile;

namespace MyRun.MVC.Controllers
{
    public class RunnerProfileController : Controller
    {
        private readonly IMediator _mediator;

        public RunnerProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRunnerProfileCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Create));
        }
        //CREATE

        //GET PROFILE
        public async Task<IActionResult> Index()
        {
            var dto = await _mediator.Send(new GetRunnerProfileQuery());
            return View(dto);
        }
        //GET PROFILE
    }
}
