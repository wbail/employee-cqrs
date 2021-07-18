using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WBail.EmployeeControl.Features.Employees.Services;
using WBail.EmployeeControl.Models;

namespace WBail.EmployeeControl.Features.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
        {
            private readonly IEmployeeService _employeeService;

            public CreateEmployeeCommandHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            public async Task<Employee> Handle(CreateEmployeeCommand employee, CancellationToken cancellationToken)
            {
                var newEmployee = new Employee
                {
                    Name = employee.Name,
                    Birthdate = employee.Birthdate,
                    Email = employee.Email
                };

                return await _employeeService.CreateEmployee(newEmployee);
            }
        }
    }
}
