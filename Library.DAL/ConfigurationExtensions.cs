using Library.DAL.Interfaces;
using Library.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace Library.DAL
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureDAL(
            this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
