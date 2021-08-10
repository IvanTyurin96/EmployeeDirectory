using AutoMapper;
using Employees.Application.Common.Exceptions;
using Employees.Application.Employees.Queries.GetEmployeesList;
using Employees.Application.Interfaces;
using Employees.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsVm>
    {
        private readonly IEmployeesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeDetailsHandler(IEmployeesDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<EmployeeDetailsVm> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees
                .Include(employee => employee.Department)
                .FirstOrDefaultAsync(employee => employee.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            var map = _mapper.Map<EmployeeDto>(entity);
            return new EmployeeDetailsVm { Employee = map };
        }
    }
}
