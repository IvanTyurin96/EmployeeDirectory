using Employees.Application.Common.Mappings;
using Employees.Application.Employees.Commands.CreateEmployee;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Employees.Web.Models
{
    public class CreateEmployeeDto : IMapWith<CreateEmployeeCommand>
    {
        [Required(ErrorMessage = "Не указано ФИО")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан отдел")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указана фотография")]
        public IFormFile Photo { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<CreateEmployeeDto, CreateEmployeeCommand>()
                .ForMember(createCommand => createCommand.Name, opt => opt.MapFrom(createDto => createDto.Name))
                .ForMember(createCommand => createCommand.DepartmentId, opt => opt.MapFrom(createDto => createDto.DepartmentId))
                .ForMember(createCommand => createCommand.PhoneNumber, opt => opt.MapFrom(createDto => createDto.PhoneNumber))
                .ForMember(createCommand => createCommand.Photo, opt => opt.MapFrom(createDto => createDto.Photo));
        }
    }
}
