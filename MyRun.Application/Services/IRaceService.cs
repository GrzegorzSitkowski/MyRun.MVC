using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Services
{
    public interface IRaceService
    {
        Task Create(Domain.Entities.Race race);
    }
}
