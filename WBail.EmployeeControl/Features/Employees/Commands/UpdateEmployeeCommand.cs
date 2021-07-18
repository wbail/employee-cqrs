using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WBail.EmployeeControl.Features.Employees.Services;

namespace WBail.EmployeeControl.Features.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private readonly IEmployeeService _employeeService;

            public UpdateEmployeeCommandHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            public async Task<int> Handle(UpdateEmployeeCommand employee, CancellationToken cancellationToken)
            {
                var updateEmployee = await _employeeService.GetEmployeeById(employee.Id);

                if (updateEmployee == null)
                {
                    return default;
                }

                updateEmployee.Name = employee.Name;
                updateEmployee.Birthdate = employee.Birthdate;
                updateEmployee.Email = employee.Email;

                return await _employeeService.UpdateEmployee(updateEmployee);
            }
        }
    }
}
