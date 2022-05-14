using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.CountryDomain
{
    public class InsertCountryCommand : ICreateAggregateCommand
    {
        public string Name { get; set; }

        public InsertCountryCommand(string name)
        {
            Name = name;
        }
    }
}
