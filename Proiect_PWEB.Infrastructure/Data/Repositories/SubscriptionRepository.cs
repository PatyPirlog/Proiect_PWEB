using Microsoft.EntityFrameworkCore;
using Proiect_PWEB.Core;
using Proiect_PWEB.Core.Domain.SubscriptionDomain;
using System.Linq;
using System.Text;

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
            StringBuilder sb = new StringBuilder("[SUBSCRIBER] ");

            foreach (var command in commands)
            {
                var subscription = command.Description is null ? new Subscription(command.UserId, command.CountryId) :
                                    new Subscription(command.UserId, command.CountryId, command.Description);

                await _context.Subscription.AddAsync(subscription, cancellationToken);
                var countryName = _context.Country
                    .Where(country => country.Id == command.CountryId)
                    .Select(country => country.Name)
                    .ToString();

                sb.Append($"{countryName};");
                
            }
            sb.Remove(sb.Length - 1, 1);

            await SaveAsync(cancellationToken);
            Console.Out.WriteLine(sb);
        }

        public async Task DeleteSubscriptionAsync(Guid id, CancellationToken cancellationToken)
        {
            var subscription = await _context.Subscription
                   .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (subscription != null)
            {
                _context.Subscription.Remove(subscription);
            }

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
