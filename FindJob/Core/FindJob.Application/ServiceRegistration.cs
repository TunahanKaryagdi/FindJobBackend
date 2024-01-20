using FindJob.Application.Utilities.File;
using FindJob.Persistence.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FindJob.Application
{
    public static class ServiceRegistration
    {

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddScoped<IFileHelper, FileHelper>();

        }
    }
}
