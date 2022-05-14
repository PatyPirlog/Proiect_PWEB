namespace Proiect_PWEB.Api.Features.Request.AddRequest
{
    public interface IAddRequestCommandHandler
    {
        public Task HandleAsync(AddRequestCommand command, CancellationToken cancellationToken);
    }
}
