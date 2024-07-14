using Microsoft.Extensions.DependencyInjection;
using Test.BLL;
using Test.DAL;

namespace Test.IoC
{
    public static class DependencyContainter
    {
        public static IServiceCollection BookManagerService(this IServiceCollection services) 
        {
            //services.AddScoped<BookService>();
            services.AddRepository();
            services.AddBookService();

            return services;
        }

    }
}
