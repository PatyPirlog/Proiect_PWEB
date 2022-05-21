namespace Proiect_PWEB.Api.Features.Request.GetRequest
{
    public class RequestWithDetailsDTO : RequestDTO
    {
        public string UserEmail { get; set; }
        public RequestWithDetailsDTO(Guid id,
            string categoryName,
            string countryName,
            string title,
            string address,
            string description,
            string userEmail,
            string name,
            string surname,
            string phone) 
            : base(id, categoryName, countryName, title, address, description, name, surname, phone)
        {
            UserEmail = userEmail;
        }
    }
}
