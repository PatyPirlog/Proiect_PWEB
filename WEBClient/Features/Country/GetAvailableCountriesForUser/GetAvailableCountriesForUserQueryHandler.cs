using Proiect_PWEB.Core.Domain.CountryDomain;
using Proiect_PWEB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Proiect_PWEB.Api.Features.Country.GetAllCountries;
using Proiect_PWEB.Api.Web;

namespace Proiect_PWEB.Api.Features.Country.GetAvailableCountriesForUser
{
    public class GetAvailableCountriesForUserQueryHandler : IGetAvailableCountriesForUserQueryHandler
    {
        private readonly PwebContext _context;

        public GetAvailableCountriesForUserQueryHandler(PwebContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<CountryDTO>> HandleAsync(Guid id, CancellationToken cancellation)
        {
            var subscriptionsCountryGuids = await _context.Subscription
                .Where(s => s.UserId == id)
                .Select(s => s.CountryId)
                .ToListAsync(cancellation);

            if(!subscriptionsCountryGuids.Any())
                throw new ApiException(System.Net.HttpStatusCode.Conflict, $"Couldn't find any subscriptions for the user!");
            
            var countries = await _context.Country
                    .AsNoTracking()
                    .Where(country => !subscriptionsCountryGuids.Contains(country.Id))
                    .Select(country => new CountryDTO(country.Id,
                    country.Name
                    )).ToListAsync(cancellation);

            return countries;
        }
    }
}
