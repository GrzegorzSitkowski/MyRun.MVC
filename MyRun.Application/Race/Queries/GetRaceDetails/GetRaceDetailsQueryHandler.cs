using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetRaceDetailsQueryHandler(IRaceRepository raceRepository, IMapper mapper)
        {
            _raceRepository = raceRepository;
            _mapper = mapper;
        }

        public async Task<RaceDto> Handle(GetRaceDetailsQuery request, CancellationToken cancellationToken)
        {
            var race = await _raceRepository.GetById(request._idRace);

            var dto = _mapper.Map<RaceDto>(race);

            return dto;
        }
    }
}
