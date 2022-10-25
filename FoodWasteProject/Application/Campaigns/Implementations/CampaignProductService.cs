/* Campaign module - Asociación Lista y Valiente & Imborrables
 * Collaborators:
 * - Jimena Gdur
 * - Fabian Gonzales
 * - Maeva Murcia
 */

/* Project includes */
using Domain.Campaigns.DTOs;
using Domain.Campaigns.Entities;
using Domain.Campaigns.Repositories;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Campaigns.Implementations
{
    internal class CampaignProductService : ICampaignProductService
    {
        private readonly ICampaignProductRepository _campaignProductRepository;

        public CampaignProductService(ICampaignProductRepository campaignProductRepository)
        {
            _campaignProductRepository = campaignProductRepository;
        }

        /// <summary>
        /// Adds given campaignProduct.
        /// </summary>
        /// <param name="campaign"></param>
        public async Task AddCampaignProductAsync(CampaignProduct campaignProduct)
        {
            await _campaignProductRepository.AddCampaignProductAsync(campaignProduct);
        }

        public async Task<IList<CampaignProductDTO>> GetCampaignProductByIdAsync(int id)
        {
            return await _campaignProductRepository.getAllCampaignProductsById(id);
        }
    }
}
