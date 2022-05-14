using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.RequestDomain
{
    public class RequestDomain : DomainOfAggregate<Request>
    {
        public RequestDomain(Request aggregate) : base(aggregate)
        {
        }
    }
}
