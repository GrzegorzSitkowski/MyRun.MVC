using AutoMapper;
using MyRun.Application.Race;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IMapper _mapper;

        public RaceService(IRaceRepository raceRepository, IMapper mapper)
        {
            _raceRepository = raceRepository;
            _mapper = mapper;
        }

        public async Task Create(RaceDto raceDto)
        {
            var race = _mapper.Map<Domain.Entities.Race>(raceDto);

            await _raceRepository.Create(race);
        }

        public async Task<IEnumerable<RaceDto>> GetAll()
        {
            var races = await _raceRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<RaceDto>>(races);

            return dtos;
        }
    }
}
