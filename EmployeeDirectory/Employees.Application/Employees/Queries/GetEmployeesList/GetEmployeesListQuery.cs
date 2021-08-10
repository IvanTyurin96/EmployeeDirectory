using MediatR;


namespace Employees.Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery : IRequest <EmployeesListVm>
    {
        public int PageNumber { get; set; }

        public string SearchString { get; set; }
    }
}
