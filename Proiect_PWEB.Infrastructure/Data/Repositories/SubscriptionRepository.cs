using Microsoft.EntityFrameworkCore;
using Proiect_PWEB.Core;
using Proiect_PWEB.Core.Domain.SubscriptionDomain;
using System.Linq;

namespace Proiect_PWEB.Infrastructure.Data.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly PwebContext _context;

        public SubscriptionRepository(PwebContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InsertSubscriptionCommand command, CancellationToken cancellationToken)
        {
            var subscription = command.Description is null ? new Subscription(command.UserId, command.CountryId) :
                                    new Subscription(command.UserId, command.CountryId, command.Description);

            await _context.Subscription.AddAsync(subscription, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public async Task AddMultipleAsync(List<InsertSubscriptionCommand> commands, CancellationToken cancellationToken)
        {
            foreach (var command in commands)
            {
                var subscription = command.Description is null ? new Subscription(command.UserId, command.CountryId) :
                                    new Subscription(command.UserId, command.CountryId, command.Description);

                await _context.Subscription.AddAsync(subscription, cancellationToken);
                
            }
            await SaveAsync(cancellationToken);
        }

        public async Task DeleteSubscriptionAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<DomainOfAggregate<Subscription>?> GetByIdAsync(Guid aggregateId, CancellationToken cancellationToken)
        {
            var subscription = await _context.Subscription.FirstOrDefaultAsync(subscription => subscription.Id == aggregateId, cancellationToken);

            if (subscription == null)
                return null;

            return new SubscriptionDomain(subscription);

        }

        public Task SaveAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
    }
}
