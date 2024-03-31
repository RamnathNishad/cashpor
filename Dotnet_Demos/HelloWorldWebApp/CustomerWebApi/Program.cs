using EFCoreCodeFirstDemo;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //configure dependency injection for DbContext
            builder.Services.AddDbContext<CustomerDbContext>(options =>
            {
                var constr = builder.Configuration.GetConnectionString("sqlconstr");
                options.UseSqlServer(constr);
            });






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "api/{controller=Home}/{action=Index}/{id?}");




            app.Run();
        }
    }
}
