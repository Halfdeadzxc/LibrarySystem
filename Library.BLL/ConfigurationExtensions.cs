using Library.BLL.Interfaces;
using Library.BLL.MappingProfiles;
using Library.BLL.Services;
using Library.DAL;
using Microsoft.Extensions.DependencyInjection;


namespace Library.BLL
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureBLL(this IServiceCollection services)
        {
            services.ConfigureDAL();
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<IBookService, BookService>();
        }
    }
}
