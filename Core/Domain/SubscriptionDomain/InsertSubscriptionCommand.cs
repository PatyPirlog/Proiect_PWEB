using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.SubscriptionDomain
{
    public class InsertSubscriptionCommand : ICreateAggregateCommand
    {
        public string IdentityId { get; set; }
        public Guid CountryId { get; set; }

        public InsertSubscriptionCommand(string identityId, Guid countryId)
        {
            IdentityId = identityId;
            CountryId = countryId;
        }

    }
}
