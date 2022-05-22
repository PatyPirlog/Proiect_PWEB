namespace Proiect_PWEB.Api.Features.EmailSender
{
    public static class EmailSenderModulecs
    {
        public static void AddEmailSenderHandler(this IServiceCollection services)
        {
            services.AddTransient<IEmailSenderHandler, EmailSenderHandler>();
        }
    }
}
