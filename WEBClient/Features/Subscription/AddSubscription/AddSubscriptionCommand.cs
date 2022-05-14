using Proiect_PWEB.Core.Domain.SubscriptionDomain;

namespace Proiect_PWEB.Api.Features.Subscription.AddSubscription
{
    public class AddSubscriptionCommand : InsertSubscriptionCommand
    {
        public AddSubscriptionCommand(
            string? description,
            Guid userId,
            Guid countryId)
            : base(description, userId, countryId)
        {
        }
    }
}
