using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core
{
    public interface IRepositoryOfAggregate<TAggregate, TAggregateCreateCommand>
        where TAggregate : Entity, IAggregateRoot
        where TAggregateCreateCommand : ICreateAggregateCommand
    {
        Task AddAsync(TAggregateCreateCommand command, CancellationToken cancellationToken);
        Task<DomainOfAggregate<TAggregate>?> GetAsync(int aggregateId, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
