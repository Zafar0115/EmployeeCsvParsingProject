using EmployeeTask.Data;
using EmployeeTask.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Tests.Common
{
    public static class EmployeesContextFactory
    {
        public static readonly string PayyrollNumberForDelete = Guid.NewGuid().ToString();
        public static readonly string PayyrollNumberForUpdate = Guid.NewGuid().ToString();
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            
            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            context.Employees.AddRange(new List<Employee>
            {
                 new Employee
            {
                PayyrollNumber = PayyrollNumberForDelete,
                Forename = "John",
                Surname = "Doe",
                DateOfBirth = "01/01/1990",
                Telephone = "123-456-7890",
                Mobile = "987-654-3210",
                Address = "123 Main St",
                Address2 = "Apt 456",
                Postcode = "12345",
                EmailHome = "john.doe@example.com",
                StartDate = "05/01/2022"
            },
                  new Employee
            {
                PayyrollNumber = PayyrollNumberForUpdate,
                Forename = "Alex",
                Surname = "Doe",
                DateOfBirth = "01/10/1990",
                Telephone = "123-456-7890",
                Mobile = "987-654-3210",
                Address = "123 Main St",
                Address2 = "Apt 456",
                Postcode = "12345",
                EmailHome = "alex.doe@example.com",
                StartDate = "05/01/2022"
            },
                   new Employee
            {
                PayyrollNumber = "P003AC",
                Forename = "Tom",
                Surname = "Wilson",
                DateOfBirth = "14/01/1990",
                Telephone = "123-456-7890",
                Mobile = "987-654-3210",
                Address = "123 Main St",
                Address2 = "Apt 456",
                Postcode = "12345",
                EmailHome = "tom.doe@example.com",
                StartDate = "08/10/2022"
            }
            });

            return context;
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
