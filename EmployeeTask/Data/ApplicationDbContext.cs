using EmployeeTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTask.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}
