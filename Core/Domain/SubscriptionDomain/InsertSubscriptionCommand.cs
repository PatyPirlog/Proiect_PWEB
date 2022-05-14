using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.SubscriptionDomain
{
    public class InsertSubscriptionCommand : ICreateAggregateCommand
    {
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }

        public InsertSubscriptionCommand(string? description, Guid userId, Guid countryId)
        {
            Description = description;
            UserId = userId;
            CountryId = countryId;
        }

    }
}
