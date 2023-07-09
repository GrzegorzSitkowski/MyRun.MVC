using MyRun.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Infrastructure.Seeders
{
    public class RaceSeeder
    {
        private readonly MyRunDbContext _dbContext;

        public RaceSeeder(MyRunDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.Races.Any())
                {
                    var marathonPoznan = new Domain.Entities.Race()
                    {
                        Name = "Marathon Poznan",
                        Country = "Poland",
                        City = "Poznan",
                        Number = "5175",
                        Place = "1827",
                        Distance = "42.197",
                        Result = "03:47:56",
                        AveragePace = "05:16",
                        Date = DateTime.Now,
                        Note = "PB",
                        CreatedAt = DateTime.Now
                    };
                    _dbContext.Races.Add(marathonPoznan);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
