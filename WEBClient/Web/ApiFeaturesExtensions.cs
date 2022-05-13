using Proiect_PWEB.Api.Features.User;

namespace Proiect_PWEB.Api.Web
{
    public static class ApiFeaturesExtensions
    {
        public static void AddApiFeaturesHandlers(this IServiceCollection services)
        {
            // Add User Handlers
            services.AddUserHandlers();

            // Add Profile Handlers
            //services.AddProfilesHandlers();

            // Add Rentals Handlers
            //services.AddRentalsHandlers();

            // Add Metrics Handlers
            //services.AddMetricsHandlers();
        }
    }
}
