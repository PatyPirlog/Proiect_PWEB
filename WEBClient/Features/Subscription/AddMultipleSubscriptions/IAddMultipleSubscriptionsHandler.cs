using Proiect_PWEB.Api.Features.Subscription.AddSubscription;

namespace Proiect_PWEB.Api.Features.Subscription.AddMultipleSubscriptions
{
    public interface IAddMultipleSubscriptionsHandler
    {
        public Task HandleAsync(List<AddSubscriptionCommand> command, CancellationToken cancellationToken);
    }
}
