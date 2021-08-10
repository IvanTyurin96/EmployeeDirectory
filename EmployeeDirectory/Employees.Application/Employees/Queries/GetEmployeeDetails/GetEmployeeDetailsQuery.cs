using MediatR;

namespace Employees.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsVm>
    {
        public int Id { get; set; }
    }
}
