namespace Proiect_PWEB.Api.Features.Request
{
    public class RequestDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string CountryName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public RequestDTO(
            Guid id,
            string categoryName,
            string countryName,
            string title,
            string address,
            string description,
            string name,
            string surname,
            string phone)
        {
            Id = id;
            CategoryName = categoryName;
            CountryName = countryName;
            Title = title;
            Address = address;
            Description = description;
            Name = name;
            Surname = surname;
            Phone = phone;
        }
    }
}
