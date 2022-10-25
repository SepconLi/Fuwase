/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * 
 * - Summary: Interface of Campaign Service
 *   Calls infrastructure methods to add, read, modify and delete campaigns on database
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
    public interface ICampaignService
    {
        /// <summary>
        /// Adds given campaign along with it's products
        /// </summary>
        /// <param name="campaign"></param>
        Task AddCampaignAsync(Campaign campaign);

        Task<IEnumerable<CampaignDTO>> GetCampaignsAsync();

        Task<Campaign?> GetByIdAsync(int id);

    }
}