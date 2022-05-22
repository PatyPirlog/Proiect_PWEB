namespace Proiect_PWEB.Api.Features.EmailSender
{
    public class EmailDTO
    {
        public string ToEmail { get; set; }
        public List<string> Countries { get; set; } = new List<string>();

        public EmailDTO(string toEmail, List<string> countries)
        {
            ToEmail = toEmail;
            Countries.AddRange(countries);
        }
    }
}
