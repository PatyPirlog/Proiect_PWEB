using Proiect_PWEB.Api.Features.EmailSender;
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

        public async Task HandleAsync(AddSubscriptionCommand command, CancellationToken cancellationToken)
        {
            await subscriptionRepository
               .AddAsync(new AddSubscriptionCommand(command.IdentityId, command.Email, command.CountryId), cancellationToken);
        }
             
    }
}
