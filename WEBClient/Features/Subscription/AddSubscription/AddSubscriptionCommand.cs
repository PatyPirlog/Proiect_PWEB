using Proiect_PWEB.Core.Domain.SubscriptionDomain;

namespace Proiect_PWEB.Api.Features.Subscription.AddSubscription
{
    public class AddSubscriptionCommand : InsertSubscriptionCommand
    {
        public string Email {get; set;}
        public AddSubscriptionCommand(
            String identityId,
            string email,
            Guid countryId)
            : base(identityId, countryId)
        {
            this.Email = email;
        }
    }
}
