using Proiect_PWEB.Core.Domain.UserDomain;

namespace Proiect_PWEB.Api.Features.User.AddUser
{
    public class AddUserCommand : InsertUserCommand
    {
        public AddUserCommand(
            string name,
            string surname,
            string email, 
            string phone
            )
            : base(name, surname, email, phone)
        {
        }
    }
}
