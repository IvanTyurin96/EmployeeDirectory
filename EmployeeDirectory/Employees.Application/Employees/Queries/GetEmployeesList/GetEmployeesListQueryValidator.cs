using FluentValidation;

namespace Employees.Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQueryValidator : AbstractValidator<GetEmployeesListQuery>
    {
        public GetEmployeesListQueryValidator()
        {
            RuleFor(query => query.PageNumber).GreaterThan(0);
        }
    }
}
