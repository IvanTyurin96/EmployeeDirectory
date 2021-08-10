using Employees.Application.Common.Models;
using System.Collections.Generic;

namespace Employees.Application.Employees.Queries.GetEmployeesList
{
    public class EmployeesListVm
    {
        public IList<EmployeeDto> Employees { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
