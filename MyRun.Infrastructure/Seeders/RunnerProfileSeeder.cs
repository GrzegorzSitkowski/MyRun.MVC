using MyRun.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Infrastructure.Seeders
{
    public class RunnerProfileSeeder
    {
        private readonly MyRunDbContext _dbContext;

        public RunnerProfileSeeder(MyRunDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.RunnerProfiles.Any())
                {
                    var myProfile = new Domain.Entities.RunnerProfile()
                    {
                        FullName = "Grzegorz Sitkowski",
                        Age = 28,
                        Weight = "80",
                        Pb5k = "00:20:46",
                        Pb10k = "00:43:21",
                        PbHalfMarathon = "01:42:18",
                        PbFullMarathon = "03:42:36",
                        About = "Amator runner, live in Poznan",
                        Accomplishments = "Finished Runmagedon and marathon in Budapest - 2019"
                    };

                    _dbContext.RunnerProfiles.Add(myProfile);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
