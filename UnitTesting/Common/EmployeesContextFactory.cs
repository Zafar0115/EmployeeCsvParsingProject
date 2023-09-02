using EmployeeTask.Data;
using EmployeeTask.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Tests.Common
{
    public class EmployeesContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options=new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();
            context.Employees.AddRange(new List<Employee>
            {
                new Employee() {PayyrollNumber="AAAA", Mobile }
            }
                );
        }
    }
}
