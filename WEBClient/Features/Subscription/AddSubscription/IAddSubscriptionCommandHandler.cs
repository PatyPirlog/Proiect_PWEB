namespace Proiect_PWEB.Api.Features.Subscription.AddSubscription
{
    public interface IAddSubscriptionCommandHandler
    {
        public Task HandleAsync(AddSubscriptionCommand command, CancellationToken cancellationToken);
    }
}
