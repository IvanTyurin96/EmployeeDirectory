using Employees.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;


namespace Employees.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, string wwwroot)
        {
            var connectionString = configuration["DbConnection"];

            services.Configure<PhotoFileOptions>(options =>
            {                
                options.BasePhotoDirectory = Path.Combine(wwwroot, "img");
            });

            services.AddDbContext<EmployeesDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IEmployeesDbContext>(provider => provider.GetService<EmployeesDbContext>());
            return services;
        }
    }
}
