using Employees.Tests.Common;
using EmployeeTask.CQRS.Queries;
using EmployeeTask.Models;
using Shouldly;

namespace Employees.Tests.Tests.Queries
{
    public class EmployeeRetrieveAllTest : TestCommandBase
    {
        [Fact]
        public async Task EmployeeRetrieveAll_Success()
        {
            //Arrange
            var handler = new EmployeeRetrieveAllQueryHandler(context);

            //Act
            var result = await handler.Handle(new EmployeeRetrieveAllQuery(), CancellationToken.None);


            //Assert
            result.Count().ShouldBeGreaterThanOrEqualTo(0);
        }
    }
}
