using Proiect_PWEB.Api.Features.Country.GetAllCountries;

namespace Proiect_PWEB.Api.Features.Country.GetAvailableCountriesForUser
{
    public interface IGetAvailableCountriesForUserQueryHandler
    {
        public Task<IEnumerable<CountryDTO>> HandleAsync(string identityId, CancellationToken cancellation);
    }
}
