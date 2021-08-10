using System.Collections.Generic;

namespace Employees.Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
