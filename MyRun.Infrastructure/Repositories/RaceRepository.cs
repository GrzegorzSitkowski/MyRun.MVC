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
    public class RaceRepository : IRaceRepository
    {
        private readonly MyRunDbContext _dbContext;
        private readonly IUserContext _userContext;

        public RaceRepository(MyRunDbContext dbContext, IUserContext userContext)
        {
            _dbContext = dbContext;
            _userContext = userContext;
        }

        public Task Commit()
            => _dbContext.SaveChangesAsync();

        public async Task Create(Race race)
        {
            _dbContext.Add(race);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Race>> GetAll()
            => await _dbContext.Races.Where(c => c.CreatedById == _userContext.GetCurrentUser().Id).
            ToListAsync();

        public async Task<Race> GetById(int id)
            => await _dbContext.Races.FirstAsync(c => c.Id == id);

        public async Task Delete(int id)
        {
            var race = _dbContext.Races.Find(id);
            if(race != null)
            {
                _dbContext.Races.Remove(race);
                await _dbContext.SaveChangesAsync();
            }     
        }
    }
}
