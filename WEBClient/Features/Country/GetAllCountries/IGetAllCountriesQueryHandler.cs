namespace Proiect_PWEB.Api.Features.Country.GetAllCountries
{
    public interface IGetAllCountriesQueryHandler
    {
        public Task<IEnumerable<CountryDTO>> HandleAsync(CancellationToken cancellationToken);
    }
}
