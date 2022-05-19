using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Features.Subscription.AddMultipleSubscriptions;
using Proiect_PWEB.Api.Features.Subscription.AddSubscription;
using Proiect_PWEB.Api.Features.Subscription.DeleteSubscription;
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
        private readonly IAddMultipleSubscriptionsHandler addMultiplesSubscriptionsHandler;
        private readonly IDeleteSubscriptionHandler deleteSubscriptionHandler;

        public SubscriptionController(
            IAddSubscriptionCommandHandler addSubscriptionCommandHandler,
            IGetAllSubscriptionsForUserQueryHandler getAllSubscriptionsForUserQueryHandler,
            IAddMultipleSubscriptionsHandler addMultiplesSubscriptionsHandler,
            IDeleteSubscriptionHandler deleteSubscriptionHandler)
        {
            this.addSubscriptionCommandHandler = addSubscriptionCommandHandler;
            this.getAllSubscriptionsForUserQueryHandler = getAllSubscriptionsForUserQueryHandler;
            this.addMultiplesSubscriptionsHandler = addMultiplesSubscriptionsHandler;
            this.deleteSubscriptionHandler = deleteSubscriptionHandler;
        }

        [HttpPost("addSubscription")]
        [Authorize]
        public async Task<IActionResult> AddSubscriptionAsync([FromBody] AddSubscriptionCommand command, CancellationToken cancellationToken)
        {
            await addSubscriptionCommandHandler.HandleAsync(command, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("getAllSubscriptionsForUser")]
        [Authorize]
        public async Task<IActionResult> GetAllSubscriptionsForUser(Guid id, CancellationToken cancellationToken)
        {
            var subscriptions = await getAllSubscriptionsForUserQueryHandler.HandleAsync(id, cancellationToken);

            return Ok(subscriptions);
        }

        [HttpPost("addMultipleSubscriptions")]
        [Authorize]
        public async Task<IActionResult> AddMultipleSubscriptions([FromBody] List<AddSubscriptionCommand> commands, CancellationToken cancellationToken)
        {
            if (commands == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            await addMultiplesSubscriptionsHandler.HandleAsync(commands, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("deleteSubscription")]
        [Authorize]
        public async Task<IActionResult> DeleteSubscription(Guid id, CancellationToken cancellationToken)
        {
            await deleteSubscriptionHandler.HandleAsync(id, cancellationToken);

            return StatusCode((int)HttpStatusCode.OK);
        }

    }
}
