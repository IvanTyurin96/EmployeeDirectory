using Employees.Application.Common.Mappings;
using Employees.Application.Employees.Commands.UpdateEmployee;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Employees.Web.Models
{
    public class UpdateEmployeeDto : IMapWith<UpdateEmployeeCommand>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано ФИО")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан отдел")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        public string PhoneNumber { get; set; }

        public IFormFile Photo { get; set; }


        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<UpdateEmployeeDto, UpdateEmployeeCommand>()
                 .ForMember(updateCommand => updateCommand.Id, opt => opt.MapFrom(updateDto => updateDto.Id))
                .ForMember(updateCommand => updateCommand.Name, opt => opt.MapFrom(updateDto => updateDto.Name))
                .ForMember(updateCommand => updateCommand.DepartmentId, opt => opt.MapFrom(updateDto => updateDto.DepartmentId))
                .ForMember(updateCommand => updateCommand.PhoneNumber, opt => opt.MapFrom(updateDto => updateDto.PhoneNumber))
                .ForMember(updateCommand => updateCommand.Photo, opt => opt.MapFrom(updateDto => updateDto.Photo));
        }
    }
}
