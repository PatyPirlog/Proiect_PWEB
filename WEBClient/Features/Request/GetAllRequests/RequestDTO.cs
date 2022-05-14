namespace Proiect_PWEB.Api.Features.Request
{
    public class RequestDTO
    {
        public Guid Id { get; set; }
        // public Guid UserId { get; set; }
        // public Guid CategoryId { get; set; }
        // public Guid CountryId { get; set; }
        public string UserName { get; set; }
        public string CategoryName { get; set; }
        public string CountryName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public RequestDTO(
            Guid id,
            string userName,
            string categoryName,
            string countryName,
            string title,
            string address,
            string description)
        {
            Id = id;
            UserName = userName;
            CategoryName = categoryName;
            CountryName = countryName;
            Title = title;
            Address = address;
            Description = description;
        }
    }
}
