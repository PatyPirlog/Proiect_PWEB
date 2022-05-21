using Proiect_PWEB.Core.Domain.SubscriptionDomain;

namespace Proiect_PWEB.Api.Features.Subscription.AddSubscription
{
    public class AddSubscriptionCommand : InsertSubscriptionCommand
    {
        public AddSubscriptionCommand(
            String identityId,
            Guid countryId)
            : base(identityId, countryId)
        {
        }
    }
}
