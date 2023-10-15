using Microsoft.EntityFrameworkCore;
using MyRun.Application.ApplicationUser;
using MyRun.Domain.Entities;
using MyRun.Domain.Interfaces;
using MyRun.Infrastructure.Persistance;

namespace MyRun.Infrastructure.Repositories
{	
    public class RunnerProfileRepository : IRunnerProfileRepository
    {
        private readonly MyRunDbContext _dbContext;
        private readonly IUserContext _userContext;

        public RunnerProfileRepository(MyRunDbContext dbContext, IUserContext userContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }

        public async Task Create(RunnerProfile runnerProfile)
        {
            _dbContext.Add(runnerProfile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RunnerProfile> GetProfile(int id)
            => await _dbContext.RunnerProfiles.FirstOrDefaultAsync(c => c.CreatedById == _userContext.GetCurrentUser().Id);

        public Task Commit()
            => _dbContext.SaveChangesAsync();
            
    }
}
