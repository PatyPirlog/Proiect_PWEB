using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public User(string name, string surname, string email, string phone)
        {
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
        }

        public virtual ICollection<Request> Request { get; set; } = new List<Request>();
    }
}
