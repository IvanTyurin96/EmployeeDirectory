using AutoMapper;
using Employees.Application.Common.Mappings;
using Employees.Domain;

namespace Employees.Application.Employees.Queries.GetEmployeesList
{
    public class EmployeeDto : IMapWith<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDto>()
                .ForMember(employeeDto => employeeDto.Id, opt => opt.MapFrom(employee => employee.Id))
                .ForMember(employeeDto => employeeDto.Name, opt => opt.MapFrom(employee => employee.Name))
                .ForMember(employeeDto => employeeDto.Department, opt => opt.MapFrom(employee => employee.Department.Name))
                .ForMember(employeeDto => employeeDto.DepartmentId, opt => opt.MapFrom(employee => employee.Department.Id))
                .ForMember(employeeDto => employeeDto.PhoneNumber, opt => opt.MapFrom(employee => employee.PhoneNumber))
                .ForMember(employeeDto => employeeDto.Photo, opt => opt.MapFrom(employee => employee.Photo));
        }
    }
}
