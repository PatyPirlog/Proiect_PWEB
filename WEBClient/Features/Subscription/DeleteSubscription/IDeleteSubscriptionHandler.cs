namespace Proiect_PWEB.Api.Features.Subscription.DeleteSubscription
{
    public interface IDeleteSubscriptionHandler
    {
        public Task HandleAsync(Guid id, CancellationToken cancellation);
    }
}
