using Microsoft.EntityFrameworkCore;
using MyRun.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public WorkoutRepository(MyRunDbContext dbContext, IUserContext userContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }

        public async Task Commit()
            => await _dbContext.SaveChangesAsync();

        public async Task Create(Workout workout)
        {
            _dbContext.Add(workout);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var workout = _dbContext.Workouts.Find(id);

            if(workout != null)
            {
                _dbContext.Workouts.Remove(workout);
                await _dbContext.SaveChangesAsync();
            }    
        }

        public async Task<IEnumerable<Workout>> GetAll()
            => await _dbContext.Workouts.Where(c => c.CreatedById == _userContext.GetCurrentUser().Id).ToListAsync();

        public async Task<Workout> GetById(int id)
            => await _dbContext.Workouts.FirstAsync(c => c.Id == id);
    }
}
