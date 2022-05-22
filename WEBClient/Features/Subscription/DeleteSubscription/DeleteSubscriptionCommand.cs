namespace Proiect_PWEB.Api.Features.Subscription.DeleteSubscription
{
    public class DeleteSubscriptionCommand
    {
        public Guid Id { get; set; }

        public DeleteSubscriptionCommand(Guid id)
        {
            Id = id;
        }
    }
}
