using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.UserDomain
{
    public class UserDomain : DomainOfAggregate<User>
    {
        public UserDomain(User aggregate) : base(aggregate)
        {
        }

        public void UpdateUser()
        {

        }

        public void RemoveUser()
        {

        }
    }
}
