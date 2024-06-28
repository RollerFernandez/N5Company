using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5.Management.Permissions.Application.Commands.Definitions;
using N5.Management.Permissions.Application.Queries.Definitions;

namespace N5.Management.Permissions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPermission(int id)
        {
            var query = new GetPermissionQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult> SetPermission(CreatePermissionCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut()]
        public async Task<ActionResult> UpdatePermission(UpdatePermissionCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
