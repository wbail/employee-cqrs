using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBail.EmployeeControl.Database;
using WBail.EmployeeControl.Models;

namespace WBail.EmployeeControl.Features.Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeService(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _employeeContext.Employee.Add(employee);
            await _employeeContext.SaveChangesAsync();
            return employee;
        }

        public async Task<int> DeleteEmployee(Employee employee)
        {
            _employeeContext.Employee.Remove(employee);
            return await _employeeContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeContext.Employee.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            return await _employeeContext.Employee.ToListAsync();
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _employeeContext.Employee.Update(employee);
            return await _employeeContext.SaveChangesAsync();
        }
    }
}
