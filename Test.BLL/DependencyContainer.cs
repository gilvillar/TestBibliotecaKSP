using Microsoft.Extensions.DependencyInjection;
using Test.Entities;

namespace Test.BLL
{
    /// <summary>
    /// Esta clase se utiliza para crear un metodo de extension que permita el registro de servicios
    /// de negocio
    /// </summary>
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //registramos el repositorio de libros
            services.AddScoped<IBookService, BookService>();

            //registramos el repositorio de usuario
            services.AddScoped<IUserService, AuthService>();

            return services;
        }
    }
}
