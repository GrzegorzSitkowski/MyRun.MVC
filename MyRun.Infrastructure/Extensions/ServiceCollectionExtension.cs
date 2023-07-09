using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRun.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Register DbContext and get ConnectionString
            services.AddDbContext<MyRunDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("MyRun")));
            //Register DbContext and get ConnectionString
        }
    }
}
