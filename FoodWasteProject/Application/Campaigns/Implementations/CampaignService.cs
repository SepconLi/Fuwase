/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Campaign's service
 */

/* Project includes */
using Domain.Core.Repositories;
using Domain.Campaigns.DTOs;
using Domain.Campaigns.Entities;
using Domain.Campaigns.Repositories;
using Domain.Products.Repositories;
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Campaigns.Implementations {
    internal class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository) {
            _campaignRepository = campaignRepository;
        }

        /// <summary>
        /// Adds given campaign along with it's products
        /// </summary>
        /// <param name="campaign"></param>
        public async Task AddCampaignAsync(Campaign campaign) {
            await _campaignRepository.AddCampaignAsync(campaign);
        }

        public async Task<IEnumerable<CampaignDTO>> GetCampaignsAsync()
        {
            return await _campaignRepository.GetAllAsync();
        }

        public async Task<Campaign?> GetByIdAsync(int id)
        {
            return await _campaignRepository.GetByIdAsync(id);
        }

    }
}
