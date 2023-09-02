using Employees.Tests.Common;
using EmployeeTask.CQRS.Commands;
using EmployeeTask.Models;

namespace Employees.Tests.Tests.Commands
{
    public class EmployeeAddRangeHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task EmployeeAddRangeHandler_Success()
        {
            //Arrange
            var handler = new EmployeeAddRangeCommandHandler(context);
            string payrollNumber1 = Guid.NewGuid().ToString();
            string forename1 = "Jack";

            string payrollNumber2 = Guid.NewGuid().ToString();
            string forename2 = "Alex";

            //Act
            int rows = await handler.Handle(new EmployeeAddRangeCommand
            {
                Employees = new List<Employee>() {
                new Employee() {
                    PayyrollNumber = payrollNumber1,
                    Forename = forename1,
                    Surname = "Doe",
                    DateOfBirth = "01/01/1990",
                    Telephone = "123-456-7890",
                    Mobile = "987-654-3210",
                    Address = "123 Main St",
                    Address2 = "Apt 456",
                    Postcode = "12345",
                    EmailHome = "john.doe@example.com",
                    StartDate = "05/01/2022" },
                new Employee() {
                    PayyrollNumber = payrollNumber2,
                    Forename = forename2,
                    Surname = "Doe",
                    DateOfBirth = "01/01/1990",
                    Telephone = "123-456-7890",
                    Mobile = "987-654-3210",
                    Address = "123 Main St",
                    Address2 = "Apt 456",
                    Postcode = "12345",
                    EmailHome = "john.doe@example.com",
                    StartDate = "05/01/2022" }
            }
            }, CancellationToken.None);

            //Assert
            Assert.NotNull(context.Employees.FirstOrDefault(emp =>
                           emp.PayyrollNumber == payrollNumber1 && emp.Forename == forename1));
            Assert.Equal(2, rows);
        }
    }
}
