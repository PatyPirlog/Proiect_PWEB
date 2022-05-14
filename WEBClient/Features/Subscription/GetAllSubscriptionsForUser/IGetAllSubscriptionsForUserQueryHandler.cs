namespace Proiect_PWEB.Api.Features.Subscription.GetAllSubscriptionsForUser
{
    public interface IGetAllSubscriptionsForUserQueryHandler
    {
        public Task<IEnumerable<SubscriptionDTO>> HandleAsync(Guid id, CancellationToken cancellationToken);
    }
}
