using EmployeeTask.Data;
using EmployeeTask.Models;
using MediatR;

namespace EmployeeTask.CQRS.Queries
{
    public class EmployeeRetrieveAllQuery:IRequest<IQueryable<Employee>>
    {
    }

    public class EmployeeRetrieveAllQueryHandler : IRequestHandler<EmployeeRetrieveAllQuery, IQueryable<Employee>>
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRetrieveAllQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IQueryable<Employee>> Handle(EmployeeRetrieveAllQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dbContext.Employees.AsQueryable());
        }
    }

}
