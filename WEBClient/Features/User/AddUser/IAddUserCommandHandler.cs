namespace Proiect_PWEB.Api.Features.User.AddUser
{
    public interface IAddUserCommandHandler
    {
        public Task HandleAsync(AddUserCommand command, CancellationToken cancellationToken);
    }
}
