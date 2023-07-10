using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Domain.Interfaces
{
    public interface IRaceRepository
    {
        Task Create(Entities.Race race);
    }
}
