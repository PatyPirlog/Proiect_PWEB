using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Core.Domain.CountryDomain
{
    public interface ICountryRepository : IRepositoryOfAggregate<Country, InsertCountryCommand>
    {
        public Task DeleteCountryAsync(Country model, CancellationToken cancellationToken);
    }
}
