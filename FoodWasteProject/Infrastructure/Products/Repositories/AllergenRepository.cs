/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Allergen's repository
 */

/* Project includes */
using Domain.Core.Repositories;
using Domain.Products.DTOs;
using Domain.Products.Entities;
using Domain.Products.Repositories;
using Infrastructure.Products;
/* System includes */
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Products.Repositories
{
    internal class AllergenRepository : IAllergenRepository
    {
        private readonly ProductDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public AllergenRepository(ProductDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
		/// Returns allergens stored in the database associated with a category
		/// </summary>
		/// <param name="category"></param>
        public async Task<IEnumerable<Allergen>> GetAllergenByCategory
            (string category)
        {
            return await _dbContext.Allergens
                .Where(t => t.Category == category)
                .OrderBy(t => t.Name)
                .Select(t => new Allergen(t.Name, t.Description, t.Category))
                .ToListAsync();
        }

        /// <summary>
		/// Returns allergen categories stored in the database
		/// </summary>
        public async Task<IEnumerable<AllergenCategory>> GetCategories()
        {
            return await _dbContext.AllergenCategories
                .Select(t => new AllergenCategory(t.Name, t.Icon))
                .ToListAsync();
        }
    }
}
