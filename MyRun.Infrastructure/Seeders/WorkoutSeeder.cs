using Microsoft.EntityFrameworkCore;
using MyRun.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Infrastructure.Seeders
{
    public class WorkoutSeeder
    {
        private readonly MyRunDbContext _dbContext;

        public WorkoutSeeder(MyRunDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.Workouts.Any())
                {
                    var workout = new Domain.Entities.Workout()
                    {
                        Distance = "10.00 km",
                        Result = "00:58:14",
                        AveragePace = "05:58",
                        MaxPace = "04:54",
                        Calories = "250",
                        Note = "Too warm.",
                        CreatedAt = DateTime.Now
                    };

                    _dbContext.Workouts.Add(workout);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
