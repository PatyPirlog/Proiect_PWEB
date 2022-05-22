namespace Proiect_PWEB.Api.Features.EmailSender
{
    public interface IEmailSenderHandler
    {
        public Task HandleAsync(EmailDTO model);
    }
}
