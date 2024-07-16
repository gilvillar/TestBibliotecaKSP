using Microsoft.Extensions.DependencyInjection;
using Test.Entities;

namespace Test.DAL
{
    /// <summary>
    /// Esta clase se utiliza para crear un metodo de extension que permita el registro de servicios
    /// del repositorio
    /// </summary>
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            //registramos el repositorio de libros
            services.AddScoped<IBookRepository, BookRepository>();
            
            //registramos el repositorio de usuario
            services.AddScoped<IUserRepository, UserRepository>();
                
            return services;
        }
    }
}
