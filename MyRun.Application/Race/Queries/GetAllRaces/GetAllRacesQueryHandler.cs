using AutoMapper;
using MediatR;
using MyRun.Domain.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace MyRun.Application.Race.Queries.GetAllRaces
{
    public class GetAllRacesQueryHandler : IRequestHandler<GetAllRacesQuery, IEnumerable<RaceDto>>
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IMapper _mapper;

        public GetAllRacesQueryHandler(IRaceRepository raceRepository, IMapper mapper)
        {
            _raceRepository = raceRepository;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<RaceDto>> Handle(GetAllRacesQuery request, CancellationToken cancellationToken)
        {
            var races = await _raceRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<RaceDto>>(races);

            return dtos;
        }
    }
}
