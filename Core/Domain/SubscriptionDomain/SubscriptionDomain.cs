using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.SubscriptionDomain
{
    public class SubscriptionDomain : DomainOfAggregate<Subscription>
    {
        public SubscriptionDomain(Subscription aggregate) : base(aggregate)
        {
        }
    }
}
