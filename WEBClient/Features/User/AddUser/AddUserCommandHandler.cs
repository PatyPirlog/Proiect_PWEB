using Proiect_PWEB.Core.Domain.UserDomain;

namespace Proiect_PWEB.Api.Features.User.AddUser
{
    public class AddUserCommandHandler : IAddUserCommandHandler
    {
        private readonly IUserRepository userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task HandleAsync(AddUserCommand command, CancellationToken cancellationToken)
            => userRepository.AddAsync(new InsertUserCommand(command.Name, command.Surname, command.Email, command.Phone), cancellationToken);
        
    }
}
