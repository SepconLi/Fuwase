/* Campaign module - Asociación Lista y Valiente & Imborrables
 * Collaborators:
 * - Jimena Gdur
 * - Fabian Gonzales
 * - Maeva Murcia
 */
/* Project includes */
using Domain.Campaigns.DTOs;
using Domain.Campaigns.Entities;
using Domain.Core.Repositories;
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Campaigns.Repositories
{
    public interface ICampaignProductRepository
    {
        /// <summary>
        /// Adds a campaignProduct to the database
        /// </summary>
        /// <param name="campaignProduct"></param>
        Task AddCampaignProductAsync(CampaignProduct campaignProduct);

        /// <summary>
		/// Returns campaignProduct stored in the database associated with an id
		/// </summary>
		/// <param name="id"></param>
        Task<IList<CampaignProductDTO>> getAllCampaignProductsById(int id);

    }
}
