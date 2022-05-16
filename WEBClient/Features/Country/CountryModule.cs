﻿using Proiect_PWEB.Api.Features.Country.GetAllCountries;
using Proiect_PWEB.Api.Features.Country.GetAvailableCountriesForUser;

namespace Proiect_PWEB.Api.Features.Country
{
    public static class CountryModule
    {
        public static void AddCountriesHandlers(this IServiceCollection services)
        {
            services.AddTransient<IGetAllCountriesQueryHandler, GetAllCountriesQueryHandler>();
            services.AddTransient<IGetAvailableCountriesForUserQueryHandler, GetAvailableCountriesForUserQueryHandler>();
        }
    }
}
