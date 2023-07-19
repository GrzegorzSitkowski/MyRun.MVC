using MediatR;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Race.Commands.EditRace
{
    public class EditRaceCommandHandler : IRequestHandler<EditRaceCommand>
    {
        private readonly IRaceRepository _raceRepository;

        public EditRaceCommandHandler(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }

        public async Task<Unit> Handle(EditRaceCommand request, CancellationToken cancellationToken)
        {
            var race = await _raceRepository.GetById(request.Id!);

            race.Name = request.Name;
            race.Country = request.Country;
            race.City = request.City;
            race.Number = request.Number;
            race.Place = request.Place;
            race.Distance = request.Distance;
            race.Result = request.Result;
            race.AveragePace = request.AveragePace;
            race.Date = request.Date;
            race.Note = request.Note;
        }
    }
}
