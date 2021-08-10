using Employees.Application.Common.Exceptions;
using Employees.Application.Interfaces;
using Employees.Domain;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeesDbContext _dbContext;

        public DeleteEmployeeCommandHandler(IEmployeesDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Employees.FindAsync(new object[] { request.Id }, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            var filePhoto = Path.Combine(_dbContext.BasePhotoDirectory, Path.GetFileName(entity.Photo));
            if(File.Exists(filePhoto))
            {
                File.Delete(filePhoto);
            }

            _dbContext.Employees.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
