using Proiect_PWEB.Api.Features.Request.AddRequest;
using Proiect_PWEB.Api.Features.Request.GetAllRequests;
using Proiect_PWEB.Api.Features.Request.GetRequest;

namespace Proiect_PWEB.Api.Features.Request
{
    public static class RequestModule
    {
        public static void AddRequestHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAddRequestCommandHandler, AddRequestCommandHandler>();
            services.AddTransient<IGetAllRequestsQueryHandler, GetAllRequestsQueryHandler>();
            services.AddTransient<IGetRequestQueryHandler, GetRequestQueryHandler>();
        }
    }
}
