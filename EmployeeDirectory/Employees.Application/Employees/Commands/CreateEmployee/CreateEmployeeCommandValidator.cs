using FluentValidation;

namespace Employees.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(createEmployeeCommand => createEmployeeCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(createEmployeeCommand => createEmployeeCommand.DepartmentId).NotEmpty();
            RuleFor(createEmployeeCommand => createEmployeeCommand.PhoneNumber).NotEmpty().Length(18);
            RuleFor(createEmployeeCommand => createEmployeeCommand.Photo).NotEmpty();
        }
    }
}
