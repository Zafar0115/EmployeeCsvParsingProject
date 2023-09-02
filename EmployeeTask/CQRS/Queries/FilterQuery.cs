using EmployeeTask.Data;
using EmployeeTask.Models;
using MediatR;

namespace EmployeeTask.CQRS.Queries
{
    public class FilterQuery:IRequest<IEnumerable<Employee>?>
    {
        public string sortingOrder { get; set; } = "asc";
        public string search { get; set; } = "";
    }

    public class FilterQueryHandler : IRequestHandler<FilterQuery, IEnumerable<Employee>?>
    {
        private readonly ApplicationDbContext _dbContext;

        public FilterQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<Employee>?> Handle(FilterQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Employee> filteredEmployees = _dbContext.Employees;

            if (request.search != null&& request.search!="")
            {
                request.search = request.search.ToLower();
                filteredEmployees = filteredEmployees
                .Where(emp =>
                 emp.PayyrollNumber.ToLower().Contains(request.search) ||
                 emp.Forename.ToLower().Contains(request.search) ||
                 emp.Surname.ToLower().Contains(request.search) ||
                 emp.StartDate.ToLower().Contains(request.search) ||
                 emp.Address.ToLower().Contains(request.search) ||
                 emp.Address2.ToLower().Contains(request.search) ||
                 emp.Telephone.ToLower().Contains(request.search) ||
                 emp.Postcode.ToLower().Contains(request.search) ||
                 emp.EmailHome.ToLower().Contains(request.search) ||
                 emp.Mobile.ToLower().Contains(request.search));
            }
            if (filteredEmployees is not null)
                filteredEmployees = request.sortingOrder.ToLower() == "desc" ? filteredEmployees
                                   .OrderByDescending(emp => emp.Surname) :
                                   filteredEmployees.OrderBy(emp => emp.Surname);

            return Task.FromResult(filteredEmployees);
        }
    }
}
