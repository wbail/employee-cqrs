using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WBail.EmployeeControl.Features.Employees.Services;

namespace WBail.EmployeeControl.Features.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
        {
            private readonly IEmployeeService _employeeService;

            public DeleteEmployeeCommandHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            public async Task<int> Handle(DeleteEmployeeCommand employee, CancellationToken cancellationToken)
            {
                var deleteEmployee = await _employeeService.GetEmployeeById(employee.Id);

                if (deleteEmployee == null)
                {
                    return default;
                }

                return await _employeeService.DeleteEmployee(deleteEmployee);
            }
        }
    }
}
