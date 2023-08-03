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
    public class RunnerProfileRepository : IRunnerProfileRepository
    {
        private readonly MyRunDbContext _dbContext;

        public RunnerProfileRepository(MyRunDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(RunnerProfile runnerProfile)
        {
            _dbContext.Add(runnerProfile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RunnerProfile> GetProfile(int id)
            => await _dbContext.RunnerProfiles.FirstAsync(c => c.Id == id);

        public Task Commit()
            => _dbContext.SaveChangesAsync();
            
    }
}
