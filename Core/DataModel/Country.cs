using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core
{
    public class Country : Entity, IAggregateRoot
    {
        public string Name { get; set; }

        public Country(string name)
        {
            Name = name;
        }

        public virtual ICollection<Request> Request { get; set; } = new List<Request>();
        public virtual ICollection<Subscription> Subscription { get; set; } = new List<Subscription>();
    }
}
