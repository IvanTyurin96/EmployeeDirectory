using Employees.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Interfaces
{
    public interface IEmployeesDbContext
    {
        string BasePhotoDirectory { get; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<string> SavePhotoAsync(IFormFile photo, CancellationToken cancellationToken);
    }
}
