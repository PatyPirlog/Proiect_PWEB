using Proiect_PWEB.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core
{
    public class User : Entity, IAggregateRoot
    {
        public string? IdentityId { get; set; }
        public string Email { get; set; }
        public User(string identityId, string email)
        {
            this.IdentityId = identityId;
            this.Email = email;
        }

        public virtual ICollection<Request> Request { get; set; } = new List<Request>();
        public virtual ICollection<Subscription> Subscription { get; set; } = new List<Subscription>();
    }
}
