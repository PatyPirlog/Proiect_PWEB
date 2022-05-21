using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_PWEB.Api.Authorization;
using Proiect_PWEB.Api.Features.Country.GetAllCountries;
using Proiect_PWEB.Api.Features.Country.GetAvailableCountriesForUser;

namespace Proiect_PWEB.Api.Features.Country
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IGetAllCountriesQueryHandler getAllCountriesQueryHandler;
        private readonly IGetAvailableCountriesForUserQueryHandler getAvailableCountriesForUserQueryHandler;

        public CountryController(IGetAllCountriesQueryHandler getAllCountriesQueryHandler,
            IGetAvailableCountriesForUserQueryHandler getAvailableCountriesForUserQueryHandler)
        {
            this.getAllCountriesQueryHandler = getAllCountriesQueryHandler;
            this.getAvailableCountriesForUserQueryHandler = getAvailableCountriesForUserQueryHandler;
    }

        [HttpGet("getAllCountries")]
        [Authorize]
        public async Task<IActionResult> GetAllCountriesAsync(CancellationToken cancellationToken)
        {
            var countries = await getAllCountriesQueryHandler.HandleAsync(cancellationToken);

            return Ok(countries);
        }

        [HttpGet("getAvailableCountriesForUser")]
        [Authorize]
        public async Task<IActionResult> GetAvailableCountriesForUserAsync(CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }
            var countries = await getAvailableCountriesForUserQueryHandler.HandleAsync(identityId, cancellationToken);

            return Ok(countries);
        }


    }
}
