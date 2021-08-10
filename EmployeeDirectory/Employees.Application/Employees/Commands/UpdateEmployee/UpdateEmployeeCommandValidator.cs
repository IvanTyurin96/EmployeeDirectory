using FluentValidation;

namespace Employees.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(updateEmployeeCommand => updateEmployeeCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(updateEmployeeCommand => updateEmployeeCommand.DepartmentId).NotEmpty();
            RuleFor(updateEmployeeCommand => updateEmployeeCommand.PhoneNumber).NotEmpty().Length(18);
        }
    }
}
