using Employees.Application.Common;
using Employees.Application.Common.Exceptions;
using Employees.Application.Interfaces;
using Employees.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeesDbContext _dbContext;

        public UpdateEmployeeCommandHandler(IEmployeesDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees
                .Include(employee => employee.Department)
                .FirstOrDefaultAsync(employee => employee.Id == request.Id, cancellationToken);
            
            if(entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            entity.Name = request.Name;
            entity.DepartmentId = request.DepartmentId;
            entity.PhoneNumber = PhoneNumberHandler.HandlePhoneNumber(request.PhoneNumber);
            
            if (request.Photo != null)
            {
                var filePhoto = Path.Combine(_dbContext.BasePhotoDirectory, Path.GetFileName(entity.Photo));
                if (File.Exists(filePhoto))
                {
                    File.Delete(filePhoto);
                }

                entity.Photo = await _dbContext.SavePhotoAsync(request.Photo, cancellationToken);
            }
           
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
