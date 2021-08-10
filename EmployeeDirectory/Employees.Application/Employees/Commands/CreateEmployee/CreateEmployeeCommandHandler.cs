using Employees.Application.Common;
using Employees.Application.Interfaces;
using Employees.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeesDbContext _dbContext;

        public CreateEmployeeCommandHandler(IEmployeesDbContext dbContext) => _dbContext = dbContext;

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                DepartmentId = request.DepartmentId,
                PhoneNumber = PhoneNumberHandler.HandlePhoneNumber(request.PhoneNumber),
                Photo =  await _dbContext.SavePhotoAsync(request.Photo, cancellationToken)
            };

            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
