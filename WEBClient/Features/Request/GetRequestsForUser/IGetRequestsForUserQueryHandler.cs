using Proiect_PWEB.Api.Features.Request.GetRequest;

namespace Proiect_PWEB.Api.Features.Request.GetRequestsForUser
{
    public interface IGetRequestsForUserQueryHandler
    {
        public Task<IEnumerable<RequestWithDetailsDTO>> HandleAsync(Guid id, CancellationToken cancellationToken);
    }
}
