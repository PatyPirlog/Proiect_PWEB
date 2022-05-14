namespace Proiect_PWEB.Api.Features.Request.GetRequest
{
    public class RequestWithDetailsDTO : RequestDTO
    {
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public RequestWithDetailsDTO(Guid id,
            string userName,
            string categoryName,
            string countryName,
            string title,
            string address,
            string description,
            string userPhone,
            string userEmail) 
            : base(id, userName, categoryName, countryName, title, address, description)
        {
            UserPhone = userPhone;
            UserEmail = userEmail;
        }
    }
}
