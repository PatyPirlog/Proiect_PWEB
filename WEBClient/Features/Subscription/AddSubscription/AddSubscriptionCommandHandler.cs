using Proiect_PWEB.Core.Domain.SubscriptionDomain;

namespace Proiect_PWEB.Api.Features.Subscription.AddSubscription
{
    public class AddSubscriptionCommandHandler : IAddSubscriptionCommandHandler
    {
        private readonly ISubscriptionRepository subscriptionRepository;

        public AddSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        public Task HandleAsync(AddSubscriptionCommand command, CancellationToken cancellationToken)
            => subscriptionRepository
            .AddAsync(new AddSubscriptionCommand(command.IdentityId, command.CountryId), cancellationToken);
    }
}
