using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public virtual ICollection<Request> Request { get; set; } = new List<Request>();
    }
}
