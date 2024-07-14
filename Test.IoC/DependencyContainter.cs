using Microsoft.Extensions.DependencyInjection;
using Test.BLL;
using Test.DAL;

namespace Test.IoC
{
    public static class DependencyContainter
    {
        public static IServiceCollection ManagerService(this IServiceCollection services) 
        {
            services.AddRepository();
            services.AddServices();

            return services;
        }

    }
}
