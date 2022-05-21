using Proiect_PWEB.Api.Web;
using Proiect_PWEB.Core.Domain.SubscriptionDomain;

namespace Proiect_PWEB.Api.Features.Subscription.DeleteSubscription
{
    public class DeleteSubscriptionHandler : IDeleteSubscriptionHandler
    {
        private readonly ISubscriptionRepository subscriptionRepository;

        public DeleteSubscriptionHandler(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        public async Task HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var subscription = await subscriptionRepository.GetByIdAsync(id, cancellationToken);

            if (subscription == null)
            {
                throw new ApiException(System.Net.HttpStatusCode.NotFound, $"Subscription with id {id} was not found.");
            }

            await subscriptionRepository.DeleteSubscriptionAsync(id, cancellationToken);
            await subscriptionRepository.SaveAsync(cancellationToken);
        }
    }
}
