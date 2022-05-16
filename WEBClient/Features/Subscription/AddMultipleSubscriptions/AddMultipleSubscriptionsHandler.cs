using Proiect_PWEB.Api.Features.Subscription.AddSubscription;
using Proiect_PWEB.Core.Domain.SubscriptionDomain;

namespace Proiect_PWEB.Api.Features.Subscription.AddMultipleSubscriptions
{
    public class AddMultipleSubscriptionsHandler :IAddMultipleSubscriptionsHandler
    {
        private readonly ISubscriptionRepository subscriptionRepository;

        public AddMultipleSubscriptionsHandler(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        public async Task HandleAsync(List<AddSubscriptionCommand> commands, CancellationToken cancellationToken)
        {
            var subscriptions = commands.Select(command => new InsertSubscriptionCommand(
                command.Description,
                command.UserId,
                command.CountryId))
                .ToList();

            await subscriptionRepository.AddMultipleAsync(subscriptions, cancellationToken);
        }
    }
}
