using AutoMapper;
using MediatR;
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

        public CreateRunnerProfileCommandHandler(IRunnerProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateRunnerProfileCommand request, CancellationToken cancellationToken)
        {
            var runnerProfile = _mapper.Map<Domain.Entities.RunnerProfile>(request);

            await _repository.Create(runnerProfile);

            return Unit.Value;
        }
    }
}
