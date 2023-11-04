using FindJob.Application.Abstractions;
using FindJob.Application.Repositories;
using FindJob.Persistence.Concretes;
using FindJob.Persistence.Contexts;
using FindJob.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJob.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IJobService,JobService>();
            services.AddDbContext<FindJobDbContext>(options => 
            options.UseNpgsql(Configuration.ConnectionString),ServiceLifetime.Singleton);
            services.AddSingleton<IJobReadRepository,JobReadRepository>();
            services.AddSingleton<IJobWriteRepository, JobWriteRepository>();

        }

    }
}
