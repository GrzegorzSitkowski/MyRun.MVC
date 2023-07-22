using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Race.Commands.CreateRace
{
    public class CreateRaceCommand : RaceDto, IRequest
    {
    }
}
