/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Product's repository
 */

/* Project includes */
using Domain.Core.Repositories;
using Domain.Products.DTOs;
using Domain.Products.Entities;
using Domain.Products.Repositories;
using Microsoft.Data.SqlClient;
/* System includes */
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Products.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ProductRepository(ProductDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
		/// Adds specified product in the database
		/// </summary>
		/// <param name="product"></param>
        public async Task AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<int> AddCampaignProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveEntitiesAsync();
            return product.Id;
        }

        /// <summary>
        /// Saves changes from specified product into database
        /// </summary>
        /// <param name="product"></param>
        public async Task SaveAsync(Product product)
        {
            _dbContext.Add(product);
            await _dbContext.SaveEntitiesAsync();
        }

        /// <summary>
		/// Modifies specified product in database
		/// </summary>
		/// <param name="product"></param>
        public async Task ModifyProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
        }

        /// <summary>
		/// Returns products stored in the database associated with an id
		/// </summary>
		/// <param name="id"></param>
        public async Task<IList<Product>> getProductsByOrder(int id)
        {
            //TODO: change for save exec
            var _products = await _dbContext.Products
                .FromSqlRaw($"EXEC GetProductsFromOrder @orderId",
                new SqlParameter("orderId", id)).ToListAsync();
            
            return _products;
        }
    }
}
