using FluentValidation;

namespace Employees.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(deleteEmployeeCommand => deleteEmployeeCommand.Id).NotEmpty();
        }
    }
}
