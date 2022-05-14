using Proiect_PWEB.Api.Features.Subscription.AddSubscription;

namespace Proiect_PWEB.Api.Features.Subscription
{
    public static class SubscriptionModule
    {
        public static void AddSubscriptionHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAddSubscriptionCommandHandler, AddSubscriptionCommandHandler>();
        }
    }
}
