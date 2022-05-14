using Proiect_PWEB.Core;
using Proiect_PWEB.Core.Domain.CountryDomain;

namespace Proiect_PWEB.Infrastructure.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly PwebContext _context;

        public CountryRepository(PwebContext context)
        {
            _context = context;
        }

        public Task AddAsync(InsertCountryCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCountryAsync(Country model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DomainOfAggregate<Country>?> GetByIdAsync(Guid aggregateId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
