/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Product's service
 */

/* Project includes */
using Domain.Products.Entities;
using Domain.Products.Repositories;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        /// <summary>
        /// Modifies specified product with new changes
        /// </summary>
        /// <param name="product"></param>
        public async Task ModifyProductAsync(Product product)
        {
            await _ProductRepository.ModifyProduct(product);
        }

        /// <summary>
        /// Gets all products by order using it's id
        /// </summary>
        /// <param name="id"></param>
        public async Task<IList<Product>> getProductsByOrderAsync(int id)
        {
            return await _ProductRepository.getProductsByOrder(id);
        }

        public async Task<int> AddCampaignProduct(Product product)
        {
            return await _ProductRepository.AddCampaignProduct(product);
        }
    }
}