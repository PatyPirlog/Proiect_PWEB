using Proiect_PWEB.Api.Features.Subscription.AddSubscription;
using Proiect_PWEB.Api.Features.Subscription.GetAllSubscriptionsForUser;

namespace Proiect_PWEB.Api.Features.Subscription
{
    public static class SubscriptionModule
    {
        public static void AddSubscriptionHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAddSubscriptionCommandHandler, AddSubscriptionCommandHandler>();
            services.AddTransient<IGetAllSubscriptionsForUserQueryHandler, GetAllSubscriptionsForUserQueryHandler>();
        }
    }
}
