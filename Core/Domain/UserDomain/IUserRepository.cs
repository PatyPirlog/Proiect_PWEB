using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.UserDomain
{
    public interface IUserRepository : IRepositoryOfAggregate<User, InsertUserCommand>
    {
        public Task DeleteUserAsync(User model, CancellationToken cancellationToken);
    }
}
