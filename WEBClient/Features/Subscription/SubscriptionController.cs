using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Features.Subscription.AddSubscription;
using System.Net;

namespace Proiect_PWEB.Api.Features.Subscription
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IAddSubscriptionCommandHandler addSubscriptionCommandHandler;

        public SubscriptionController(IAddSubscriptionCommandHandler addSubscriptionCommandHandler)
        {
            this.addSubscriptionCommandHandler = addSubscriptionCommandHandler;
        }

        [HttpPost("addSubscription")]
        public async Task<IActionResult> AddSubscriptionAsync([FromBody] AddSubscriptionCommand command, CancellationToken cancellationToken)
        {
            await addSubscriptionCommandHandler.HandleAsync(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }


    }
}
