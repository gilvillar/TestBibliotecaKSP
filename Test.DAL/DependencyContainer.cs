using Microsoft.Extensions.DependencyInjection;
using Test.Entities;

namespace Test.DAL
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
                
            return services;
        }
    }
}
