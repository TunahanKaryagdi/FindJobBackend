using FindJob.Application.Repositories;
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
            services.AddDbContext<FindJobDbContext>(options => 
            options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IJobReadRepository,JobReadRepository>();
            services.AddScoped<IJobWriteRepository, JobWriteRepository>();

        }

    }
}
