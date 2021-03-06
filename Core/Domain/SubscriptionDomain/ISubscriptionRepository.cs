using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.SubscriptionDomain
{
    public interface ISubscriptionRepository : IRepositoryOfAggregate<Subscription, InsertSubscriptionCommand>
    {
        public Task DeleteSubscriptionAsync(Guid id, CancellationToken cancellationToken);

        public Task AddMultipleAsync(List<InsertSubscriptionCommand> commands, CancellationToken cancellationToken);
    }
}
