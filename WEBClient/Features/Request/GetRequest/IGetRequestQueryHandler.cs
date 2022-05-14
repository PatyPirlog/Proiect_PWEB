namespace Proiect_PWEB.Api.Features.Request.GetRequest
{
    public interface IGetRequestQueryHandler 
    {
        public Task<RequestWithDetailsDTO> HandleAsync(Guid Id, CancellationToken cancellationToken);
    }
}
