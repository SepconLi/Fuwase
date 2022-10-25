/* CD-US-1.4 Add link to confirmation code email - Core Dummpers
 * 
 * Collaborators:
 * - Mariana Murillo
 * 
 * - Summary: Implementation of RedirectInformationRepository
 */
using Domain.Utilities.Repositories;
using Domain.Utilities.Entities;
using Domain.Core.Repositories;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Repositories
{
    internal class RedirectInformationRepository : IRedirectInformationRepository
    {
        protected readonly UtilitiesDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public RedirectInformationRepository(UtilitiesDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
        /// Saves redirect information in the DB.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task SaveAsync(RedirectInformation info)
        {
            _dbContext.Add(info);
            await _dbContext.SaveEntitiesAsync();
        }

        /// <summary>
        /// Returns a RedirectInformation stored in the DB for a certain hash
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public async Task<RedirectInformation?> GetRedirectInformationByHash(string hash)
        {
            IList<RedirectInformation> infoResult = await _dbContext.RedirectInfo.Where(e => e.Hash == hash).ToListAsync();
            RedirectInformation? info = null;
            if (infoResult.Length() > 0)
            {
                info = infoResult.First();
            }
            return info;
        }

        /// <summary>
        /// Returns a RedirectInformation stored in the DB for a certain email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<RedirectInformation?> GetRedirectInformationByEmail(string email)
        {
            IList<RedirectInformation> infoResult = await _dbContext.RedirectInfo.Where(e => e.Email == email).ToListAsync();
            RedirectInformation? info = null;
            if (infoResult.Length() > 0)
            {
                info = infoResult.First();
            }
            return info;
        }

        /// <summary>
        /// Deletes a RedirectInformation from DB
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task DeleteRedirectInformation(RedirectInformation info) 
        {
            _dbContext.RedirectInfo.Remove(info);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}
