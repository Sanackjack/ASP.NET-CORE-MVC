using System;
using RestFulASPNET.Features.Users.Services;
using Microsoft.Extensions.DependencyInjection;
namespace RestFulASPNET.Configs
{
    public class ServiceConfiguration
    {

        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

    }
}
