using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5.Management.Permissions.Application.Queries.Definitions;

namespace N5.Management.Permissions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult> GetListPermissionType()
        {
            var query = new GetListPermissionTypeQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
