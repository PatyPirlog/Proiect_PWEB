using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.RequestDomain
{
    public class InsertRequestCommand : ICreateAggregateCommand
    {
        public string IdentityId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CountryId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public InsertRequestCommand(
            string identityId, 
            Guid categoryId,
            Guid countryId, 
            string title, 
            string address, 
            string description,
            string name,
            string surname,
            string phone)
        {
            IdentityId = identityId;
            CategoryId = categoryId;
            CountryId = countryId;
            Title = title;
            Address = address;
            Description = description;
            Name = name;
            Surname = surname;
            Phone = phone;
        }

    }
}
