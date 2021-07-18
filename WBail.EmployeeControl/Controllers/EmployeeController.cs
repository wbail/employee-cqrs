using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WBail.EmployeeControl.Features.Employees.Commands;
using WBail.EmployeeControl.Features.Employees.Queries;

namespace WBail.EmployeeControl.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger; 

        public EmployeeController(IMediator mediator, ILogger<EmployeeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _mediator.Send(new GetEmployeeByIdQuery() { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllEmployeesQuery()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeCommand employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(employee);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error on creating employee", e);
            }

            return await Create(employee);
        }

        [HttpPatch]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCommand updateEmployee)
        {
            if (id != updateEmployee.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(updateEmployee);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error on updating employee", e);
            }

            return Ok(updateEmployee);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteEmployeeCommand() { Id = id});
            }
            catch (Exception e)
            {
                _logger.LogError("Error on deleting employee", e);
            }

            return Ok(id);
        }
    }
}
