using EmployeeTask.Data;
using EmployeeTask.Middlewares;
using EmployeeTask.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmployeeTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            builder.Services.AddScoped<CsvParserService>();


            var app = builder.Build();
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseGlobalExceptionMiddleware();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}