namespace Proiect_PWEB.Api.Features.Subscription.GetAllSubscriptionsForUser
{
    public class SubscriptionDTO
    {
        public Guid Id { get; set; }
        public string CountryName { get; set; }

        public SubscriptionDTO(Guid id, string countryName)
        {
            this.Id = id;
            this.CountryName = countryName;
        }
    }
}
