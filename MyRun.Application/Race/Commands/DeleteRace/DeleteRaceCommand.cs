using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Race.Commands.DeleteRace
{
    public class DeleteRaceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
