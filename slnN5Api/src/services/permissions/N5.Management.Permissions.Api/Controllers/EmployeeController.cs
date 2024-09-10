using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5.Management.Permissions.Application.Commands.Definitions;
using N5.Management.Permissions.Application.Dtos.Employee;
using N5.Management.Permissions.Application.Queries.Definitions;
using System.Threading.Tasks;

namespace N5.Management.Permissions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            var query = new GetEmployeeQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<ActionResult> GetListEmployee([FromQuery] EmployeeFilters filter, [FromQuery(Name = "pageNumber")] int pageNumber,[FromQuery(Name = "pageSize")] int pageSize)
        {
            var query = new GetListEmployeeQuery(filter.StartDate, filter.EndDate, filter.Status, pageNumber,pageSize);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult> SetEmployee(CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut()]
        public async Task<ActionResult> updatepermission(UpdateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete()]
        public async Task<ActionResult> deletepermission(DeleteEmployeeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
