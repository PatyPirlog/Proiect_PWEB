using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Features.User.AddUser;

namespace Proiect_PWEB.Api.Features.User
{
    public static class UserModule
    {
        // todo de adaugat in ala mare
        public static void AddUserHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAddUserCommandHandler, AddUserCommandHandler>();
        }
    }
}
