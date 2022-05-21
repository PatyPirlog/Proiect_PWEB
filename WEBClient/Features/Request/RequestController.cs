using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Authorization;
using Proiect_PWEB.Api.Features.Request.AddRequest;
using Proiect_PWEB.Api.Features.Request.DeleteRequest;
using Proiect_PWEB.Api.Features.Request.GetAllRequests;
using Proiect_PWEB.Api.Features.Request.GetRequest;
using Proiect_PWEB.Api.Features.Request.GetRequestsForUser;
using System.Net;

namespace Proiect_PWEB.Api.Features.Request
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IAddRequestCommandHandler addRequestCommandHandler;
        private readonly IGetAllRequestsQueryHandler getAllRequestsQueryHandler;
        private readonly IGetRequestQueryHandler getRequestQueryHandler;
        private readonly IGetRequestsForUserQueryHandler getAllRequestsForUserQueryHandler;
        private readonly IDeleteRequestCommandHandler deleteRequestCommandHandler;

        public RequestController(
            IAddRequestCommandHandler addRequestCommandHandler,
            IGetAllRequestsQueryHandler getAllRequestsQueryHandler,
            IGetRequestQueryHandler getRequestQueryHandler,
            IGetRequestsForUserQueryHandler getAllRequestsForUserQueryHandler,
            IDeleteRequestCommandHandler deleteRequestCommandHandler
            )
        {
            this.addRequestCommandHandler = addRequestCommandHandler;
            this.getAllRequestsQueryHandler = getAllRequestsQueryHandler;
            this.getRequestQueryHandler = getRequestQueryHandler;
            this.getAllRequestsForUserQueryHandler = getAllRequestsForUserQueryHandler;
            this.deleteRequestCommandHandler = deleteRequestCommandHandler;
    }

        [HttpPost("addRequest")]
        [Authorize]
        public async Task<IActionResult> AddRequestAsync([FromBody] AddRequestCommand command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            if (command == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            command.IdentityId = identityId;

            await addRequestCommandHandler.HandleAsync(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("getAllRequests")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetAllRequestsAsync(CancellationToken cancellationToken)
        {
            var requests = await getAllRequestsQueryHandler.HandleAsync(cancellationToken);

            return Ok(requests);
        }

        [HttpGet("getAllRequestsForUser")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetRequestsForUserAsync(CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }
            var requests = await getAllRequestsForUserQueryHandler.HandleAsync(identityId, cancellationToken);

            return Ok(requests);
        }

        [HttpGet("getRequestDetails")]
        [Authorize]
        public async Task<ActionResult<RequestWithDetailsDTO>> GetAllRequestsAsync(Guid id, CancellationToken cancellationToken)
        {
            var request = await getRequestQueryHandler.HandleAsync(id, cancellationToken);

            return Ok(request);
        }

        [HttpDelete("deleteRequest")]
        [Authorize]
        public async Task<IActionResult> DeleteRequestAsync([FromBody] Guid id, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }
            await deleteRequestCommandHandler.HandleAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
