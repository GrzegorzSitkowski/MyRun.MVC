using Microsoft.EntityFrameworkCore;
using MyRun.Domain.Entities;
using MyRun.Domain.Interfaces;
using MyRun.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Infrastructure.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly MyRunDbContext _dbContext;

        public WorkoutRepository(MyRunDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
            => await _dbContext.SaveChangesAsync();

        public async Task Create(Workout workout)
        {
            _dbContext.Add(workout);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Workout>> GetAll()
            => await _dbContext.Workouts.ToListAsync();

        public async Task<Workout> GetById(int id)
            => await _dbContext.Workouts.FirstAsync(c => c.Id == id);
    }
}
