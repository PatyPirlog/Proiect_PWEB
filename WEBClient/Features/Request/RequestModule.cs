using Proiect_PWEB.Api.Features.Request.AddRequest;
using Proiect_PWEB.Api.Features.Request.GetAllRequests;
using Proiect_PWEB.Api.Features.Request.GetRequest;
using Proiect_PWEB.Api.Features.Request.GetRequestsForUser;

namespace Proiect_PWEB.Api.Features.Request
{
    public static class RequestModule
    {
        public static void AddRequestHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAddRequestCommandHandler, AddRequestCommandHandler>();
            services.AddTransient<IGetAllRequestsQueryHandler, GetAllRequestsQueryHandler>();
            services.AddTransient<IGetRequestQueryHandler, GetRequestQueryHandler>();
            services.AddTransient<IGetRequestsForUserQueryHandler, GetRequestsForUserQueryHandler>();
        }
    }
}
