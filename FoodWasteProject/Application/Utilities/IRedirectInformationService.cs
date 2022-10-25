//CD-US-1.4 Add link to confirmation code email - Core Dummpers
//Collaborators:
//-Mariana Murillo
//Summary: Interface of RedirectInformation Service

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Utilities.Entities;

namespace Application.Utilities
{
    public interface IRedirectInformationService
    {
        /// <summary>
        /// Add a RedirectInformation to DB
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        Task AddRedirectInformationAsync(RedirectInformation info);

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
