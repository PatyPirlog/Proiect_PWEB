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

        public Task DeleteSubscriptionAsync(Subscription model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DomainOfAggregate<Subscription>?> GetByIdAsync(Guid aggregateId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
    }
}
