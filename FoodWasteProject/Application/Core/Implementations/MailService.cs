using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Implementations
{
    public class MailService : IMailService
    {
        private IConfiguration config;
        string apiKey;
        public MailService(IConfiguration _config)
        {
            config = _config;
            apiKey = config.GetValue<string>("SendGridAPIKey");
        }
        public async Task SendEmailAsync(string toEmail, string _subject, string _plainTextContent, string _htmlContent)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("foodwasteucr@gmail.com", "Food Waste");
            var subject = _subject;
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, _plainTextContent, _htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
