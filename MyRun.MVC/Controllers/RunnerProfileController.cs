using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        //GET PROFILE
        public async Task<IActionResult> Index()
        {
            var dto = await _mediator.Send(new GetRunnerProfileQuery());
            return View(dto);
        }
        //GET PROFILE
    }
}
