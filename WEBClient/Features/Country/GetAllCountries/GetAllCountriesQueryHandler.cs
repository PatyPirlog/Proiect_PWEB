using Proiect_PWEB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Proiect_PWEB.Api.Features.Country.GetAllCountries
{
    public class GetAllCountriesQueryHandler : IGetAllCountriesQueryHandler
    {
        private readonly PwebContext _context;

        public GetAllCountriesQueryHandler(PwebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CountryDTO>> HandleAsync(CancellationToken cancellationToken)
        {
            var countries = await _context.Country.Select(country => new CountryDTO(country.Id,
                country.Name
                )).ToListAsync();

            return countries;
        }
    }
}
