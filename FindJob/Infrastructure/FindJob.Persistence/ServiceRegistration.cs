
using FindJob.Application.Repositories;
using FindJob.Application.Repositories.Application;
using FindJob.Application.Services;
using FindJob.Domain.Entities.Identity;
using FindJob.Persistence.Contexts;
using FindJob.Persistence.Repositories;
using FindJob.Persistence.Repositories.Skill;
using FindJob.Persistence.Repositories.WorkingUser;
using FindJob.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FindJob.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<FindJobDbContext>(options =>
            options.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {

                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<FindJobDbContext>();

            services.AddScoped<IJobReadRepository, JobReadRepository>();
            services.AddScoped<IJobWriteRepository, JobWriteRepository>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();
            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<IQualificationReadRepository, QualificationReadRepository>();
            services.AddScoped<IQualificationWriteRepository, QualificationWriteRepository>();
            services.AddScoped<IApplicationReadRepository, ApplicationReadRepository>();
            services.AddScoped<IApplicationWriteRepository, ApplicationWriteRepository>();
            services.AddScoped<ISkillReadRepository, SkillReadRepository>();
            services.AddScoped<ISkillWriteRepository, SkillWriteRepository>();
            services.AddScoped<IWorkingUserReadRepository, WorkingUserReadRepository>();
            services.AddScoped<IWorkingUserWriteRepository, WorkingUserWriteRepository>();

        }

    }
}
