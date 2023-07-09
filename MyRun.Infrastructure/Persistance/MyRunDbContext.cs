using Microsoft.EntityFrameworkCore;
using MyRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Infrastructure.Persistance
{
    public class MyRunDbContext : DbContext
    {
        public MyRunDbContext(DbContextOptions<MyRunDbContext> options) : base(options)
        {
            
        }

        public DbSet<Race> Races { get; set; }
        public DbSet<RunnerProfile> RunnerProfiles { get; set; }
        public DbSet<Workout> Workouts { get; set; }
    }
}
