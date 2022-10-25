/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Campaign's repository
 */

/* Project includes */
using Domain.Core.Repositories;
using Domain.Campaigns.DTOs;
using Domain.Campaigns.Entities;
using Domain.Campaigns.Repositories;
using Domain.Products.Entities;
using Microsoft.Data.SqlClient;
using Domain.Products.Repositories;
/* System includes */
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Campaigns.Repositories
{
    internal class CampaignRepository : ICampaignRepository
    {

        private readonly CampaignDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public CampaignRepository(CampaignDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
		/// Adds a campaign to the database
		/// </summary>
		/// <param name="campaign"></param>
        public async Task AddCampaignAsync(Campaign campaign)
        {
            _dbContext.Campaigns.Add(campaign);
            await _dbContext.SaveEntitiesAsync();
        }

        /// <summary>
		/// Returns all Campaings stored in the database as CampaignDTOs
		/// </summary>
        public async Task<IEnumerable<CampaignDTO>> GetAllAsync()
        {
            return await _dbContext.Campaigns.Where(d => d.Status=='A').
                Select(t => new CampaignDTO(t.Id, t.CreatorEmail!, t.Name!, t.Description!, t.EndDate,
                t.StartDate, t.Goal, t.Raised, t.Delivered, (char)t.Type!, t.Province!, t.County!, 
                t.District!, t.ExactLocation!)).
                ToListAsync();
        }

        public async Task<Campaign?> GetByIdAsync(int id)
        {
            return await _dbContext.Campaigns.SingleOrDefaultAsync(t => t.Id == id);
        }

    }
}
