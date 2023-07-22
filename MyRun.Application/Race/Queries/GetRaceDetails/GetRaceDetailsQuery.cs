using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Race.Queries.GetRaceDetails
{
    public class GetRaceDetailsQuery : IRequest<RaceDto>
    {
        public int _idRace { get; set; }

        public GetRaceDetailsQuery(int idRace)
        {
            _idRace = idRace;
        }
    }
}
