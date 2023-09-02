using EmployeeTask.Data;
using EmployeeTask.Models;
using MediatR;

namespace EmployeeTask.CQRS.Commands
{
    public class EmployeeAddRangeCommand : IRequest<int>
    {
        public IEnumerable<Employee> Employees { get; set; }
    }


    public class EmployeeAddRangeCommandHandler : IRequestHandler<EmployeeAddRangeCommand, int>
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeAddRangeCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(EmployeeAddRangeCommand request, CancellationToken cancellationToken)
        {
            if (request.Employees == null) return 0;
            int employeesAdded = 0;
            
            
            foreach (Employee emp in request.Employees)
            {
                var employeeFound = await _dbContext.Employees.FindAsync(emp.PayyrollNumber);
                if (employeeFound == null)
                {
                    await _dbContext.Employees.AddAsync(emp);
                    employeesAdded++;
                }
            }

            await _dbContext.SaveChangesAsync();

            return employeesAdded;
        }
    }
}
