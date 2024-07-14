using Microsoft.Extensions.DependencyInjection;
using Test.Entities;

namespace Test.BLL
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, AuthService>();

            return services;
        }
    }
}
