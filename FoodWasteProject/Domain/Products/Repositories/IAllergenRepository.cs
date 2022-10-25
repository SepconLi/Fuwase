/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Allergen's interface for it's repository
 */

/* Project includes */
using Domain.Products.Entities;
using Domain.Core.Repositories;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Repositories
{
    public interface IAllergenRepository : IRepository<Allergen>
    {
        /// <summary>
		/// Returns allergens stored in the database associated with a category
		/// </summary>
		/// <param name="category"></param>
        Task<IEnumerable<Allergen>> GetAllergenByCategory(string category);

        /// <summary>
		/// Returns allergen categories stored in the database
		/// </summary>
        Task<IEnumerable<AllergenCategory>> GetCategories();
    }
}
