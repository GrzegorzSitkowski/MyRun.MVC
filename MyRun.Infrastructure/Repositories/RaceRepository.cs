﻿using MyRun.Domain.Entities;
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

        public RaceRepository(MyRunDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Race race)
        {
            _dbContext.Add(race);
            await _dbContext.SaveChangesAsync();
        }
    }
}