using AutoMapper;
using MediatR;
using MyRun.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public CreateRaceCommandHandler(IRaceRepository raceRepository, IMapper mapper, IUserContext userContext)
        {
            _raceRepository = raceRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateRaceCommand request, CancellationToken cancellationToken)
        {
            var race = _mapper.Map<Domain.Entities.Race>(request);

            race.CreatedById = _userContext.GetCurrentUser().Id;

            await _raceRepository.Create(race);

            return Unit.Value;
        }
    }
}
