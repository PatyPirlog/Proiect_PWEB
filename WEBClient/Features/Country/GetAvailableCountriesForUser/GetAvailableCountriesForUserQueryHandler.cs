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

        public async Task<IEnumerable<CountryDTO>> HandleAsync(string identityId, CancellationToken cancellation)
        {
            var userId = await _context.User.Where(user => user.IdentityId == identityId)
                  .Select(user => user.Id)
                  .FirstOrDefaultAsync(cancellation);

            var subscriptionsCountryGuids = await _context.Subscription
                .Where(s => s.UserId == userId)
                .Select(s => s.CountryId)
                .ToListAsync(cancellation);

            var countries = !subscriptionsCountryGuids.Any() ?
                await _context.Country
                    .AsNoTracking()
                    .Select(country => new CountryDTO(
                        country.Id,
                        country.Name
                    )).ToListAsync(cancellation)
            :
                await _context.Country
                        .AsNoTracking()
                        .Where(country => !subscriptionsCountryGuids.Contains(country.Id))
                        .Select(country => new CountryDTO(country.Id,
                        country.Name
                        )).ToListAsync(cancellation);
           
            return countries;
        }
    }
}
