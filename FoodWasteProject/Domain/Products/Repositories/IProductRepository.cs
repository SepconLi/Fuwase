/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Product's interface for it's repository
 */

/* Project includes */
using Domain.Products.DTOs;
using Domain.Products.Entities;
using Domain.Products.Repositories;
using Domain.Core.Repositories;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
		/// Adds specified product in the database
		/// </summary>
		/// <param name="product"></param>
        Task AddProduct(Product product);

        /// <summary>
        /// Saves changes from specified product into database
        /// </summary>
        /// <param name="product"></param>
        Task SaveAsync(Product product);

        /// <summary>
		/// Modifies specified product in database
		/// </summary>
		/// <param name="product"></param>
        Task ModifyProduct(Product product);

        /// <summary>
		/// Returns products stored in the database associated with an id
		/// </summary>
		/// <param name="id"></param>
        Task<IList<Product>> getProductsByOrder(int id);

        Task<int> AddCampaignProduct(Product product);

    }
}
