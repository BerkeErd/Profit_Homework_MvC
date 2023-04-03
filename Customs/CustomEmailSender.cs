using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Profit_Homework_MvC.Config;

namespace Profit_Homework_MvC.Customs
{
    public class CustomEmailSender : IEmailSender
    {
        private readonly EmailConfig _config;

        public CustomEmailSender(IOptions<EmailConfig> config)
        {
            _config = config.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using var message = new MailMessage();
            message.To.Add(new MailAddress(email));
            message.From = new MailAddress("profitdeneme@yandex.com");
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;

            using var client = new SmtpClient("smtp.yandex.com.tr", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("profitdeneme@yandex.com", "mqpgpfyybwmonsks");

            await client.SendMailAsync(message);
        }
    }

}

