using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.CountryDomain
{
    public class CountryDomain : DomainOfAggregate<Country>
    {
        public CountryDomain(Country aggregate) : base(aggregate)
        {
        }
    }
}
