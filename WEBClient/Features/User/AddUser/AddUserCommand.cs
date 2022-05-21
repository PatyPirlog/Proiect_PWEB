using Proiect_PWEB.Core.Domain.UserDomain;

namespace Proiect_PWEB.Api.Features.User.AddUser
{
    public class AddUserCommand : InsertUserCommand
    {
        public AddUserCommand(
            string? identityId,
            string email
            )
            : base(identityId, email)
        {
            
        }
    }
}
