using Proiect_PWEB.Api.Features.Subscription.AddMultipleSubscriptions;
using Proiect_PWEB.Api.Features.Subscription.AddSubscription;
using Proiect_PWEB.Api.Features.Subscription.DeleteSubscription;
using Proiect_PWEB.Api.Features.Subscription.GetAllSubscriptionsForUser;

namespace Proiect_PWEB.Api.Features.Subscription
{
    public static class SubscriptionModule
    {
        public static void AddSubscriptionHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAddSubscriptionCommandHandler, AddSubscriptionCommandHandler>();
            services.AddTransient<IGetAllSubscriptionsForUserQueryHandler, GetAllSubscriptionsForUserQueryHandler>();
            services.AddTransient<IAddMultipleSubscriptionsHandler, AddMultipleSubscriptionsHandler>();
            services.AddTransient<IDeleteSubscriptionHandler, DeleteSubscriptionHandler>();
        }
    }
}
