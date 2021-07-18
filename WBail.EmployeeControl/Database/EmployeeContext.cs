using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WBail.EmployeeControl.Models;

namespace WBail.EmployeeControl.Database
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetAssembly(typeof(EmployeeContext))
            );
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
