/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Allergen's service
 */

/* Project includes */
using Application.Products;
using Domain.Core.Repositories;
using Domain.Products.Repositories;
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Implementations
{
	public class AllergenService : IAllergenService
	{
		private readonly IAllergenRepository _AllergenRepository;
		public AllergenService(IAllergenRepository allergenRepository)
		{
			_AllergenRepository = allergenRepository;
		}
		/// <summary>
		/// Gets all allergens from a specific category
		/// </summary>
		/// <param name="category"></param>
		public async Task<IEnumerable<Allergen>> GetAllergenByCategoryAsync
			(string category) {
			return await _AllergenRepository.GetAllergenByCategory(category);
		}

		/// <summary>
		/// Gets all the allergen categories
		/// </summary>
		public async Task<IEnumerable<AllergenCategory>> GetCategoriesAsync() {
			return await _AllergenRepository.GetCategories();
		}
	}
}
