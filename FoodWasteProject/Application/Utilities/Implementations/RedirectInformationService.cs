//CD-US-1.4 Add link to confirmation code email - Core Dummpers
//Collaborators:
//-Mariana Murillo
//Summary: Implements interface of RedirectInformation Service
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Utilities.Entities;
using Domain.Utilities.Repositories;

namespace Application.Utilities.Implementations
{
    public class RedirectInformationService : IRedirectInformationService
    {
        private readonly IRedirectInformationRepository _redirectInformationRepository;
        public RedirectInformationService(IRedirectInformationRepository infoRepository)
        {
            _redirectInformationRepository = infoRepository;
        }

        /// <summary>
        /// Add a RedirectInformation to DB
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task AddRedirectInformationAsync(RedirectInformation info)
        {
            await _redirectInformationRepository.SaveAsync(info);
        }

        /// <summary>
        /// Deletes a RedirectInformation from DB
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task DeleteRedirectInformation(RedirectInformation info)
        {
            await _redirectInformationRepository.DeleteRedirectInformation(info);
        }

        /// <summary>
        /// Returns a RedirectInformation for a certain hash
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public async Task<RedirectInformation?> GetRedirectInformationByHash(string hash)
        {
            return await _redirectInformationRepository.GetRedirectInformationByHash(hash);
        }

        /// <summary>
        /// Returns a RedirectInformation for a certain email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<RedirectInformation?> GetRedirectInformationByEmail(string email)
        {
            return await _redirectInformationRepository.GetRedirectInformationByEmail(email);
        }
    }
}
