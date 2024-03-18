using BlazorPunchCard.Config;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BlazorPunchCard.Repositories
{
    public class EmailSender : IEmailSender
    {
        private readonly MailConfiguration _options;

        public EmailSender(IOptions<MailConfiguration> options)
        {
            _options = options.Value;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
        {
            var pwd = _options.Authorization.Password;

            if (string.IsNullOrEmpty(pwd))
            {
                throw new Exception("Password is Null");
            }

            await Execute(pwd, subject, htmlMessage, toEmail);
        }
        public async Task Execute(string key, string subject, string mailContent, string toEmail) 
        {
            var mailFrom = _options.Authorization.User;
            var smtpClnt = _options.Host;
            var port = _options.Port;

            if (string.IsNullOrEmpty(mailFrom))
            {
                throw new Exception("Mail from is Null");
            }

            MailMessage message = new MailMessage();
            message.From = new MailAddress(mailFrom);
            message.Subject = subject;
            message.To.Add(new MailAddress(toEmail));
            message.Body = mailContent;
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient(smtpClnt)
            {
                Port = port,
                Credentials = new NetworkCredential(mailFrom, key),
                EnableSsl = true,
            };

            await smtpClient.SendMailAsync(message);
        }
    }
}
