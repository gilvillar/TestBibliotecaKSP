using Microsoft.Extensions.DependencyInjection;
using Test.Entities;

namespace Test.BLL
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddBookService(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
