using Employees.Tests.Common;
using EmployeeTask.CQRS.Commands;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Employees.Tests.Tests.Commands
{
    public class EmployeeDeleteCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task EmployeeDeleteCommandHandler_Success()
        {
            //Arrange
            var handler = new EmployeeDeleteCommandHandler(context);


            //Act
            bool result=await handler.Handle(new EmployeeDeleteCommand
            {
                PayyrollNumber = EmployeesContextFactory.PayyrollNumberForDelete
            }, CancellationToken.None);

            //Assert
            Assert.True(result);
        }


        [Fact]
        public async Task EmployeeDeleteCommandHandler_FailOnWrongPayyroll()
        {
            //Arrange
            var handler = new EmployeeDeleteCommandHandler(context);


            //Act
            bool result=await handler.Handle(new EmployeeDeleteCommand
            {
                PayyrollNumber = Guid.NewGuid().ToString()
            }, CancellationToken.None);


            //Assert
            Assert.False(result);
        }
    }
}
