using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Features.Subscription.AddSubscription;
using Proiect_PWEB.Api.Features.Subscription.GetAllSubscriptionsForUser;
using System.Net;

namespace Proiect_PWEB.Api.Features.Subscription
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IAddSubscriptionCommandHandler addSubscriptionCommandHandler;
        private readonly IGetAllSubscriptionsForUserQueryHandler getAllSubscriptionsForUserQueryHandler;

        public SubscriptionController(IAddSubscriptionCommandHandler addSubscriptionCommandHandler, IGetAllSubscriptionsForUserQueryHandler getAllSubscriptionsForUserQueryHandler)
        {
            this.addSubscriptionCommandHandler = addSubscriptionCommandHandler;
            this.getAllSubscriptionsForUserQueryHandler = getAllSubscriptionsForUserQueryHandler;
        }

        [HttpPost("addSubscription")]
        public async Task<IActionResult> AddSubscriptionAsync([FromBody] AddSubscriptionCommand command, CancellationToken cancellationToken)
        {
            await addSubscriptionCommandHandler.HandleAsync(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("getAllSubscriptionsForUser")]
        public async Task<IActionResult> GetAllSubscriptionsForUser(Guid id, CancellationToken cancellationToken)
        {
            var subscriptions = await getAllSubscriptionsForUserQueryHandler.HandleAsync(id, cancellationToken);

            return Ok(subscriptions);
        }


    }
}
