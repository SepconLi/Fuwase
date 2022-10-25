/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of ProductType's interface for it's repository
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
    public interface IProductTypeRepository : IRepository<ProductType>
    {
        /// <summary>
		/// Returns product types stored in the database
		/// </summary>
        Task<IEnumerable<ProductType>> GetProductTypes();
    }
}
