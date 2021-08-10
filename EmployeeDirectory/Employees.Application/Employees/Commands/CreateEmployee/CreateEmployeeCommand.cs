using MediatR;
using Microsoft.AspNetCore.Http;

namespace Employees.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile Photo { get; set; }
    }
}
