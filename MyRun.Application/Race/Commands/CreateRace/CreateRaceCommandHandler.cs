using AutoMapper;
using MediatR;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Race.Commands.CreateRace
{
    public class CreateRaceCommandHandler : IRequestHandler<CreateRaceCommand>
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IMapper _mapper;

        public CreateRaceCommandHandler(IRaceRepository raceRepository, IMapper mapper)
        {
            _raceRepository = raceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateRaceCommand request, CancellationToken cancellationToken)
        {
            var race = _mapper.Map<Domain.Entities.Race>(request);

            await _raceRepository.Create(race);

            return Unit.Value;
        }
    }
}
