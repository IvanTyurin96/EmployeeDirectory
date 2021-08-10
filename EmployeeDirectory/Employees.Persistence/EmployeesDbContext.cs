using Employees.Application.Interfaces;
using Employees.Domain;
using Employees.Persistence.EntityTypeConfigurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Persistence
{
    public class EmployeesDbContext : DbContext, IEmployeesDbContext
    {
        public string BasePhotoDirectory { get; private set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> dbOptions, IOptions<PhotoFileOptions> fileOptions) : base(dbOptions) 
        {
            BasePhotoDirectory = fileOptions.Value.BasePhotoDirectory;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            base.OnModelCreating(builder);   
        }

        public async Task<string> SavePhotoAsync(IFormFile photo, CancellationToken cancellationToken)
        {
            Guid guid = Guid.NewGuid();
            var filePath = Path.Combine(BasePhotoDirectory, guid + ".jpg"); 
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
               await photo.CopyToAsync(fileStream, cancellationToken);
            }
            return "img/" + guid + ".jpg";
        }
    }
}
