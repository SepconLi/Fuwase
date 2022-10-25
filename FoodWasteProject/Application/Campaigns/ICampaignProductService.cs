/* Campaign module - Asociación Lista y Valiente & Imborrables
 * Collaborators:
 * - Jimena Gdur
 * - Fabian Gonzales
 * - Maeva Murcia
 */

/* Project includes */
using Domain.Campaigns.DTOs;
using Domain.Campaigns.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Campaigns
{
    public interface ICampaignProductService
    {
        /// <summary>
        /// Adds given campaignProduct 
        /// </summary>
        /// <param name="campaignProduct"></param>
        Task AddCampaignProductAsync(CampaignProduct campaignProduct);

        /// <summary>
        /// Return an IList campaignProduct by Id
        /// </summary>
        /// <param name="id"></param>
        Task<IList<CampaignProductDTO>> GetCampaignProductByIdAsync(int id);

    }
}
