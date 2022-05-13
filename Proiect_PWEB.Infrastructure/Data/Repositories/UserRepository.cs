using Proiect_PWEB.Core;
using Proiect_PWEB.Core.Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PwebContext _context;

        public UserRepository(PwebContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InsertUserCommand command, CancellationToken cancellationToken)
        {
            ///throw new NotImplementedException();
            var user = new User(command.Name, command.Surname, command.Email, command.Phone);

            await _context.User.AddAsync(user, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public Task DeleteUserAsync(User model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DomainOfAggregate<User>?> GetAsync(int aggregateId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
    }
}
