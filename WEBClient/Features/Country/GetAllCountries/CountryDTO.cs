namespace Proiect_PWEB.Api.Features.Country.GetAllCountries
{
    public class CountryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CountryDTO(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
