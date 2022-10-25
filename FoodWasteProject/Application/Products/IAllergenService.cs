/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Interface of Allergen Service
 */

/* Project includes */
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products
{
    public interface IAllergenService
    {
        /// <summary>
        /// Gets all allergens from a specific category
        /// </summary>
        /// <param name="category"></param>
        public Task<IEnumerable<Allergen>> GetAllergenByCategoryAsync
            (string category);

        /// <summary>
        /// Gets all the allergen categories
        /// </summary>
        public Task<IEnumerable<AllergenCategory>> GetCategoriesAsync();
    }
}
