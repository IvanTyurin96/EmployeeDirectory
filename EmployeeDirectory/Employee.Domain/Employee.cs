
namespace Employees.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }

        public Department Department { get; set; }
    }
}
