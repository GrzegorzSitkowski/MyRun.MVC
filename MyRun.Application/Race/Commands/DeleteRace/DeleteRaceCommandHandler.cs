using MediatR;
using MyRun.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Race.Commands.DeleteRace
{
    public class DeleteRaceCommandHandler : IRequestHandler<DeleteRaceCommand>
    {
        private readonly IRaceRepository _raceRepository;

        public DeleteRaceCommandHandler(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }

        public async Task<Unit> Handle(DeleteRaceCommand request, CancellationToken cancellationToken)
        {
            await _raceRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}
