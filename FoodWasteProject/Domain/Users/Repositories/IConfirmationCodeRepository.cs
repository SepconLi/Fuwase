/* CD-US-2.2 Forgot my password - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of ConfirmationCode class
 */
using Domain.Core.Repositories;
using Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users.Repositories
{
    public interface IConfirmationCodeRepository
    {
        /// <summary>
        /// Search a ConfirmationCode (entity) for a certain email address.
        /// </summary>
        /// <param name="email"></param>
        Task<ConfirmationCode?> GetCodeByEmail(string email);
        /// <summary>
        /// Save a ConfirmationCode (entity).
        /// </summary>
        /// <param name="code"></param>
        Task SaveCodeAsync(ConfirmationCode code);
        /// <summary>
        /// Delete a ConfirmationCode (entity) for a certain email address.
        /// </summary>
        /// <param name="email"></param>
        Task DeleteCodeForEmail(string email);
    }
}
