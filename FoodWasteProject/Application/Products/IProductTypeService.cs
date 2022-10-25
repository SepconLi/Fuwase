/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Interface of ProductType Service
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
    public interface IProductTypeService
    {
        /// <summary>
        /// Gets all product types
        /// </summary>
        public Task<IEnumerable<ProductType>> GetProductTypesAsync();
    }
}
