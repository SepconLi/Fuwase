/* CD-US-2.2 Forgot my password - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: MailService interface. Provides the service that allows to send emails.
 */
using Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
    public interface IConfirmationCodeService
    {
        /// <summary>
        /// Service to get a code by its email
        /// </summary>
        /// <param name="email"></param>
        Task<ConfirmationCode?> GetCodeByEmail(string email);
        /// <summary>
        /// Service to delete a code for a certain email
        /// </summary>
        /// <param name="email"></param>
        Task DeleteCodeForEmail(string email);
        /// <summary>
        /// Service to add a new code
        /// </summary>
        /// <param name="code"></param>
        Task AddConfirmationCode(ConfirmationCode code);
    }
}
