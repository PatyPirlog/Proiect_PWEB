using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core
{
    public class Subscription : Entity, IAggregateRoot
    {
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }

        public Subscription(Guid userId, Guid countryId)
        {
            this.UserId = userId;
            this.CountryId = countryId;
        }

        public Subscription(Guid userId, Guid countryId, string description)
        {
            this.UserId = userId;
            this.CountryId = countryId;
            this.Description = description;
        }

        public virtual Country Country { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
