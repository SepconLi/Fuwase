/* Campaign module - Asociación Lista y Valiente & Imborrables
 * Collaborators:
 * - Jimena Gdur
 * - Fabian Gonzales
 * - Maeva Murcia
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
    internal class CampaignProductRepository : ICampaignProductRepository
    {
        private readonly CampaignDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public CampaignProductRepository(CampaignDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
        /// Adds a campaignProduct to the database
        /// </summary>
        /// <param name="campaignProduct"></param>
        public async Task AddCampaignProductAsync(CampaignProduct campaignProduct)
        {
            _dbContext.CampaignProducts.Add(campaignProduct); 
            await _dbContext.SaveEntitiesAsync();
        }

        /// <summary>
		/// Returns all campaignProduct, related with the campaign id provided, stored in the database.
		/// </summary>
        public async Task<IList<CampaignProductDTO>> getAllCampaignProductsById(int campId)
        {
            return await _dbContext.CampaignProducts
                .Where(t => t.CampaignId == campId)
                .Select(
                    t => new CampaignProductDTO(t.Id, t.CampaignId, t.Name, t.FoodType,
                    t.ProductType, t.Quantity, t.Weight, t.Goal, t.Raised, t.Campaign)).ToListAsync();
        }
    }
}
