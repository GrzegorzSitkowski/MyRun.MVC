using MediatR;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Race.Queries.GetRaceDetails
{
    public class GetRaceDetailsQueryHandler : IRequestHandler<GetRaceDetailsQuery, RaceDto>
    {
        private readonly IRaceRepository _raceRepository;

        public GetRaceDetailsQueryHandler(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }

        public async Task<RaceDto> Handle(GetRaceDetailsQuery request, CancellationToken cancellationToken)
        {
            _raceRepository.GetById(request._idRace);
        }
    }
}
