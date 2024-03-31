using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using UsersAPI.Models;

namespace UsersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            //Add Controllers middleware
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //add the Routing middeware
            builder.Services.AddRouting();

            //configure dependency injection for DbContext class
            builder.Services.AddDbContext<UsersDBContext>();

            //configure dependency injection for DataAccess class
            builder.Services.AddScoped(typeof(IUsersDataAccess), typeof(UsersDataAccess));

            //Add cors policy
            builder.Services.AddCors(
                options =>
                {
                    options.AddPolicy("clients-allowed", opt =>
                    {
                        opt.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseRouting();           

            app.MapControllerRoute(
                name: "default",
                pattern: "api/{controller=Home}/{action=Index}/{id?}");

            app.UseCors("clients-allowed");

            app.Run();
        }
    }
}
