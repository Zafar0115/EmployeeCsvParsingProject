using EmployeeTask.Data;

namespace Employees.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ApplicationDbContext context;
        public TestCommandBase()
        {
            context = EmployeesContextFactory.Create();
        }
        public void Dispose()
        {
            EmployeesContextFactory.Destroy(context);
        }
    }
}
