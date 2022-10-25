/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of ProductType's repository
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
    internal class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ProductDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ProductTypeRepository(ProductDbContext unitOfWork) {
            _dbContext = unitOfWork;
        }

        /// <summary>
		/// Returns product types stored in the database
		/// </summary>
        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            return await _dbContext.ProductTypes
                .Select(t => new ProductType(t.Name)).ToListAsync();
        }
    }
}
