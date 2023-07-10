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

        public RaceService(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }

        public async Task Create(Domain.Entities.Race race)
        {
            await _raceRepository.Create(race);
        }
    }
}
