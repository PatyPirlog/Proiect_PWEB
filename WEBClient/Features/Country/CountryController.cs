using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Features.Country.GetAllCountries;

namespace Proiect_PWEB.Api.Features.Country
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IGetAllCountriesQueryHandler getAllCountriesQueryHandler;

        public CountryController(IGetAllCountriesQueryHandler getAllCountriesQueryHandler)
        {
            this.getAllCountriesQueryHandler = getAllCountriesQueryHandler;
        }

        [HttpGet("getAllCountries")]
        public async Task<IActionResult> GetAllCountriesAsync(CancellationToken cancellationToken)
        {
            var countries = await getAllCountriesQueryHandler.HandleAsync(cancellationToken);

            return Ok(countries);
        }

    }
}
