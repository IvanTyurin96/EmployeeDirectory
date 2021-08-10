using AutoMapper;
using AutoMapper.QueryableExtensions;
using Employees.Application.Common;
using Employees.Application.Common.Models;
using Employees.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, EmployeesListVm>
    {
        private readonly IEmployeesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeesListQueryHandler(IEmployeesDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EmployeesListVm> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var searchString = string.IsNullOrEmpty(request.SearchString) ? "" : request.SearchString;

            var phoneSearchString = PhoneNumberHandler.HandlePhoneNumber(searchString);

            var employeesSearchQuery = _dbContext.Employees
                .OrderByDescending(i => i.Id)
                .Where(employee => employee.Name.Contains(searchString) 
                    || (!string.IsNullOrEmpty(phoneSearchString) && employee.PhoneNumber.Contains(phoneSearchString)));

            int employeesCount = await employeesSearchQuery.CountAsync(cancellationToken);

            var employeesQuery = await employeesSearchQuery
                .Skip((request.PageNumber - 1) * PageViewModel.PageSize)
                .Take(PageViewModel.PageSize)
                .Include(employee => employee.Department)
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var pageViewModel = new PageViewModel (employeesCount, request.PageNumber);

            return new EmployeesListVm { Employees = employeesQuery, PageViewModel = pageViewModel };
        }
    }
}
