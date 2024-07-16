using Microsoft.Extensions.DependencyInjection;
using Test.BLL;
using Test.DAL;

namespace Test.IoC
{
    /// <summary>
    /// Esta clase se utiliza para crear un metodo de extension que permita el registro de servicios
    /// del repositorio y de los servicios de negocio
    /// </summary>
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
