using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Features.Request.AddRequest;
using Proiect_PWEB.Api.Features.Request.GetAllRequests;
using Proiect_PWEB.Api.Features.Request.GetRequest;
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

        public RequestController(
            IAddRequestCommandHandler addRequestCommandHandler,
            IGetAllRequestsQueryHandler getAllRequestsQueryHandler,
            IGetRequestQueryHandler getRequestQueryHandler
            )
        {
            this.addRequestCommandHandler = addRequestCommandHandler;
            this.getAllRequestsQueryHandler = getAllRequestsQueryHandler;
            this.getRequestQueryHandler = getRequestQueryHandler;
    }

        [HttpPost("addRequest")]
        //[Authorize]
        public async Task<IActionResult> AddRequestAsync([FromBody] AddRequestCommand command, CancellationToken cancellationToken)
        {
            await addRequestCommandHandler.HandleAsync(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("getAllRequests")]
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetAllRequestsAsync(CancellationToken cancellationToken)
        {
            var requests = await getAllRequestsQueryHandler.HandleAsync(cancellationToken);

            return Ok(requests);
        }

        [HttpGet("getRequestDetails")]
        public async Task<ActionResult<RequestWithDetailsDTO>> GetAllRequestsAsync(Guid id, CancellationToken cancellationToken)
        {
            var request = await getRequestQueryHandler.HandleAsync(id, cancellationToken);

            return Ok(request);
        }
    }
}
