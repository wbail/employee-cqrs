using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WBail.EmployeeControl.Features.Employees.Services;
using WBail.EmployeeControl.Models;

namespace WBail.EmployeeControl.Features.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
        {
            private readonly IEmployeeService _employeeService;

            public GetAllEmployeesQueryHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {
                return await _employeeService.GetEmployeeList();
            }
        }
    }
}
