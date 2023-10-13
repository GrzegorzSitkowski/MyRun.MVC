using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRun.Application.RunnerProfile.Commands.CreateRunnerProfile;
using MyRun.Application.RunnerProfile.Commands.EditRunnerProfile;
using MyRun.Application.RunnerProfile.Query.GetRunnerProfile;

namespace MyRun.MVC.Controllers
{
    public class RunnerProfileController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RunnerProfileController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //CREATE
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateRunnerProfileCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Details));
        }
        //CREATE

        //GET PROFILE
        //[Route("RunnerProfile/{id}/Details")]
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _mediator.Send(new GetRunnerProfileQuery(id));
            if(dto == null)
            {
                return RedirectToAction(nameof(Create));
            }          
            return View(dto);
        }
        //GET PROFILE

        //EDIT
        [Route("RunnerProfile/{id}/Edit")]
        public async Task<IActionResult> Edit (int id)
        {
            var dto = await _mediator.Send(new GetRunnerProfileQuery(id));

            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditRunnerProfileCommand model = _mapper.Map<EditRunnerProfileCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Route("RunnerProfile/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditRunnerProfileCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Details));
        }
        //EDIT
    }
}
