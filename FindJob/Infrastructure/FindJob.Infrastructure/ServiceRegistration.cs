﻿using FindJob.Application.Abstractions.Token;
using FindJob.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FindJob.Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, TokenHelper>();
            services.AddHttpClient();
        }

    }
}
