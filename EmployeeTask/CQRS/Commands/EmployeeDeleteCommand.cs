using EmployeeTask.Data;
using EmployeeTask.Models;
using MediatR;

namespace EmployeeTask.CQRS.Commands
{
    public class EmployeeDeleteCommand : IRequest<bool>
    {
        public string PayyrollNumber { get; set; }
    }


    public class EmployeeDeleteCommandHandler : IRequestHandler<EmployeeDeleteCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeDeleteCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(EmployeeDeleteCommand request, CancellationToken cancellationToken)
        {
            var emp=await _dbContext.Employees.FindAsync(request.PayyrollNumber);
            if (emp == null) return false;

            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
