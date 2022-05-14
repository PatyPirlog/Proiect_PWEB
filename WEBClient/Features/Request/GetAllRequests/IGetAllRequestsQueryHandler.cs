namespace Proiect_PWEB.Api.Features.Request.GetAllRequests
{
    public interface IGetAllRequestsQueryHandler
    {
        public Task<IEnumerable<RequestDTO>> HandleAsync(CancellationToken cancellationToken);
    }
}
