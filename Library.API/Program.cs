using Library.API.Middlewares;
using Library.BLL;
using Library.DAL;
using Microsoft.EntityFrameworkCore;

namespace Library.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LibraryContext>(options =>  options.UseSqlServer(builder.Configuration.GetConnectionString("Default")!));
            builder.Services.ConfigureBLL();
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new()
                {
                    Title = "Library API",
                    Version = "v1",
                    Description = "API для управления библиотекой"
                });
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<ExceptionMiddleware>();


            app.MapControllers();

            app.Run();
        }
    }
}
