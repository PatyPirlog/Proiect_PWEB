namespace Proiect_PWEB.Api.Features.Request.DeleteRequest
{
    public interface IDeleteRequestCommandHandler
    {
        public Task HandleAsync(Guid id, CancellationToken cancellation);
    }
}
