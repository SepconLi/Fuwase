/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Interface of Product Service
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
    public interface IProductService
    {
        /// <summary>
        /// Modifies specified product with new changes
        /// </summary>
        /// <param name="product"></param>
        Task ModifyProductAsync(Product product);

        /// <summary>
        /// Gets all products by order using it's id
        /// </summary>
        /// <param name="id"></param>
        Task<IList<Product>> getProductsByOrderAsync(int id);

        Task<int> AddCampaignProduct(Product product);


    }
}
