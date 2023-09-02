using Employees.Tests.Common;
using EmployeeTask.CQRS.Commands;
using Xunit;
using Xunit.Sdk;

namespace Employees.Tests.Tests.Commands
{
    public class EmployeeUpdateCommandHandlerTest:TestCommandBase
    {
        [Fact]
        public async Task EmployeeUpdateCommandHandler_Success()
        {
            //Arrange
            var handler = new EmployeeUpdateCommandHandler(context);
            string updatedName = "UpdatedName";


            //Act
            bool updated=await handler.Handle(new EmployeeUpdateCommand
            {
                PayyrollNumber = EmployeesContextFactory.PayyrollNumberForUpdate,
                Forename = updatedName,
                Surname = "Doe",
                DateOfBirth = "01/10/1990",
                Telephone = "123-456-7890",
                Mobile = "987-654-3210",
                Address = "123 Main St",
                Address2 = "Apt 456",
                Postcode = "12345",
                EmailHome = "alex.doe@example.com",
                StartDate = "05/01/2022"
            },CancellationToken.None);


            //Assert
            Assert.NotNull(context.Employees.FirstOrDefault(emp =>
                emp.PayyrollNumber == EmployeesContextFactory.PayyrollNumberForUpdate &&
                emp.Forename == updatedName));
        }

        [Fact]
        public async Task EmployeeUpdateCommandHandler_FailOnWrongPayyroll()
        {
            //Arrange
            var handler = new EmployeeUpdateCommandHandler(context);

            //Act
            bool result=await handler.Handle(new EmployeeUpdateCommand
            {
                PayyrollNumber = Guid.NewGuid().ToString()
            }, CancellationToken.None);


            //Assert
            Assert.False(result);

        }
    }
}
