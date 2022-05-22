namespace Proiect_PWEB.Api.Features.Request.DeleteRequest
{
    public class DeleteRequestCommand
    {
        public Guid Id { get; set; }
        public DeleteRequestCommand(Guid id)
        {
            Id = id;
        }
    }
}
