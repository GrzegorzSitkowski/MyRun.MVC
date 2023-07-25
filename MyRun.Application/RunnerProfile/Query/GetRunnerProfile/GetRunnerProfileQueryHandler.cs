using AutoMapper;
using MediatR;
using MyRun.Application.Race.Queries.GetAllRaces;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.RunnerProfile.Query.GetRunnerProfile
{
    public class GetRunnerProfileQueryHandler : IRequestHandler<GetRunnerProfileQuery, RunnerProfileDto>
    {
        private readonly IRunnerProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetRunnerProfileQueryHandler(IRunnerProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RunnerProfileDto> Handle(GetRunnerProfileQuery request, CancellationToken cancellationToken)
        {
            var runnerProfile = await _repository.GetProfile();

            var dto = _mapper.Map<RunnerProfileDto>(runnerProfile);

            return dto;
        }
    }
}
