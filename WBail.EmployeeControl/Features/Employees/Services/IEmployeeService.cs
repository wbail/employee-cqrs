using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBail.EmployeeControl.Models;

namespace WBail.EmployeeControl.Features.Employees.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeeList();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> CreateEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(Employee employee);
    }
}
