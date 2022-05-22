using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Text;

namespace Proiect_PWEB.Api.Features.EmailSender
{
    public class EmailSenderHandler : IEmailSenderHandler
    {
        public async Task HandleAsync(EmailDTO model)
        {
            _ = Task.Run(() =>
              {
                  MimeMessage message = new MimeMessage();

                  message.From.Add(new MailboxAddress("HelpRefugees", "helprefugeespweb@gmail.com"));

                  message.To.Add(MailboxAddress.Parse(model.ToEmail));

                  message.Subject = "Abonare HelpRefugees cu success!";

                  StringBuilder sb = new StringBuilder();
                  model.Countries.ForEach(country => sb.Append(country + " "));
                  var countriesList = sb.ToString();

                  message.Body = new TextPart("plain")
                  {
                      Text = @$"Salut,

                        Ai reusit sa te abonezi cu succes la postarile despre urmatoarele tari:
                        {countriesList}"
                  };

                  SmtpClient client = new SmtpClient();
                  try
                  {
                      client.Connect("smtp.gmail.com", 465, true);
                      client.Authenticate("helprefugeespweb@gmail.com", "HELPRefugees@1234");
                      client.Send(message);
                  }
                  catch (Exception ex)
                  {

                      Console.WriteLine(ex.Message);
                  }
                  finally
                  {
                      client.Disconnect(true);
                      client.Dispose();
                  }

              });            
        }
    }
}
