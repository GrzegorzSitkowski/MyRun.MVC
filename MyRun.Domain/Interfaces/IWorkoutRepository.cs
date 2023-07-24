using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Domain.Interfaces
{
    public interface IWorkoutRepository
    {
        Task Create(Domain.Entities.Workout workout);
        Task<IEnumerable<Domain.Entities.Workout>> GetAll();
        Task<Domain.Entities.Workout> GetById(int id);
        Task Commit();
    }
}
