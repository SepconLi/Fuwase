/* CD-US-2.2 Forgot my password - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: MailService interface. Provides the service that allows to send emails.
 */
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
    public interface IMailService
    {
        /// <summary>
        /// Sends an email for a certain destinatary, with a certain subject and content.
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="_subject"></param>
        /// <param name="_plainTextContent"></param>
        /// <param name="_htmlContent"></param>
        Task SendEmailAsync(string toEmail, string _subject, string _plainTextContent, string _htmlContent);
    }
}