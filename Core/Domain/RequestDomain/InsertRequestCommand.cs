using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.RequestDomain
{
    public class InsertRequestCommand : ICreateAggregateCommand
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CountryId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public InsertRequestCommand(Guid userId, Guid categoryId, Guid countryId, string title, string address, string description)
        {
            UserId = userId;
            CategoryId = categoryId;
            CountryId = countryId;
            Title = title;
            Address = address;
            Description = description;
        }

    }
}
