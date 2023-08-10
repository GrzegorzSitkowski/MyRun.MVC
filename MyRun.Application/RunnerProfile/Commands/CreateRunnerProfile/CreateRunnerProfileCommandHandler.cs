using AutoMapper;
using MediatR;
using MyRun.Application.ApplicationUser;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.RunnerProfile.Commands.CreateRunnerProfile
{
    public class CreateRunnerProfileCommandHandler : IRequestHandler<CreateRunnerProfileCommand>
    {
        private readonly IRunnerProfileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateRunnerProfileCommandHandler(IRunnerProfileRepository repository, IMapper mapper, IUserContext userContext)
        {
            _repository = repository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateRunnerProfileCommand request, CancellationToken cancellationToken)
        {
            var runnerProfile = _mapper.Map<Domain.Entities.RunnerProfile>(request);

            runnerProfile.CreatedById = _userContext.GetCurrentUser().Id;

            await _repository.Create(runnerProfile);

            return Unit.Value;
        }
    }
}
