using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Domain.Interfaces
{
    public interface IRunnerProfileRepository
    {
        Task<Domain.Entities.RunnerProfile> GetProfile();
    }
}
