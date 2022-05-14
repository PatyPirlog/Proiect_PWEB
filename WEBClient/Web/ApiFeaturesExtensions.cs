using Proiect_PWEB.Api.Features.Request;
using Proiect_PWEB.Api.Features.Subscription;
using Proiect_PWEB.Api.Features.User;

namespace Proiect_PWEB.Api.Web
{
    public static class ApiFeaturesExtensions
    {
        public static void AddApiFeaturesHandlers(this IServiceCollection services)
        {
            // Add User Handlers
            services.AddUserHandlers();

            // Add Subscription Handlers
            services.AddSubscriptionHandlers();

            // Add Request Handlers
            services.AddRequestHandlers();

            // Add Metrics Handlers
            //services.AddMetricsHandlers();
        }
    }
}
