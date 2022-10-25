/* CD-US-1.4 Add link to confirmation code email - Core Dummpers
 * 
 * Collaborators:
 * - Mariana Murillo
 * 
 * - Summary: Implementation of RedirectInformationRepository interface
 */
using Domain.Utilities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities.Repositories
{
    public interface IRedirectInformationRepository
    {
        /// <summary>
        /// Saves in the DB a new RedirectInformation
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task SaveAsync(RedirectInformation info);
        /// <summary>
        /// Returns a RedirectInformation for a certain hash
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        Task<RedirectInformation?> GetRedirectInformationByHash(string hash);

        /// <summary>
        /// Deletes a RedirectInformation from DB
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task DeleteRedirectInformation(RedirectInformation info);

        /// <summary>
        /// Returns a RedirectInformation for a certain email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<RedirectInformation?> GetRedirectInformationByEmail(string email);
    }
}
