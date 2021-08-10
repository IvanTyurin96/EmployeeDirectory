using MediatR;
using Microsoft.AspNetCore.Http;

namespace Employees.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile Photo { get; set; }
    }
}
