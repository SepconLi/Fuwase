/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Maeva Murcia
 * 
 * - Summary: Implementation of Campaign's interface for it's repository
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
    public interface ICampaignRepository : IRepository<Campaign>
    {
		/// <summary>
		/// Adds a campaign to the database
		/// </summary>
		/// <param name="campaign"></param>
		Task AddCampaignAsync(Campaign campaign);

		Task<IEnumerable<CampaignDTO>> GetAllAsync();

		Task<Campaign> GetByIdAsync(int id);

	}
}
