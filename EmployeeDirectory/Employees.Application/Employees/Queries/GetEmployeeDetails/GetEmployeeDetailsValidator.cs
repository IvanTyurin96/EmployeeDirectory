using FluentValidation;

namespace Employees.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsValidator : AbstractValidator<GetEmployeeDetailsQuery>
    {
        public GetEmployeeDetailsValidator()
        {
            RuleFor(employee => employee.Id).NotEmpty();
        }
    }
}
