using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WBail.EmployeeControl.Features.Employees.Services;
using WBail.EmployeeControl.Models;

namespace WBail.EmployeeControl.Features.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }

        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
        {
            private readonly IEmployeeService _employeeService;

            public GetEmployeeByIdQueryHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            public async Task<Employee> Handle(GetEmployeeByIdQuery employee, CancellationToken cancellationToken)
            {
                return await _employeeService.GetEmployeeById(employee.Id);
            }
        }
    }
}
