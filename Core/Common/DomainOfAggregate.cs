using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core
{
    public abstract class DomainOfAggregate<TAggregate> where TAggregate : Entity, IAggregateRoot
    {
        private protected readonly TAggregate aggregate;

        public DomainOfAggregate(TAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public void SoftDeleteEntity() => aggregate.IsDeleted = true;
    }
}
