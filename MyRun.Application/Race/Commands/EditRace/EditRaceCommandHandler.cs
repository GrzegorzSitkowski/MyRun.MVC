using MediatR;
using MyRun.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public EditRaceCommandHandler(IRaceRepository raceRepository, IUserContext userContext)
        {
            _raceRepository = raceRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditRaceCommand request, CancellationToken cancellationToken)
        {
            var race = await _raceRepository.GetById(request.Id!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && race.CreatedById == user.Id;

            if (!isEditable)
            {
                return Unit.Value;
            }

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

            await _raceRepository.Commit();
            return Unit.Value;
        }
    }
}
