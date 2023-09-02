using EmployeeTask.Data;
using EmployeeTask.Models;
using MediatR;

namespace EmployeeTask.CQRS.Commands
{
    public class EmployeeUpdateCommand : IRequest<bool>
    {
        public string PayyrollNumber { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
        public string EmailHome { get; set; }
        public string StartDate { get; set; }
    }


    public class EmployeeUpdateCommandHandler : IRequestHandler<EmployeeUpdateCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeUpdateCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var emp = await _dbContext.Employees.FindAsync(request.PayyrollNumber);
            if (emp == null) return false;
            

            emp.Forename = request.Forename;
            emp.Surname = request.Surname;
            emp.Postcode = request.Postcode;
            emp.StartDate = request.StartDate;
            emp.Telephone = request.Telephone;
            emp.DateOfBirth = request.DateOfBirth;
            emp.Address = request.Address;
            emp.Address2 = request.Address2;
            emp.EmailHome = request.EmailHome;
            emp.Mobile = request.Mobile;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
