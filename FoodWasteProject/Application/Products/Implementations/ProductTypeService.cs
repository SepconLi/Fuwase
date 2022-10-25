/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of ProductType's service
 */

/* Project includes */
using Application.Products;
using Domain.Core.Repositories;
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
	internal class ProductTypeService : IProductTypeService
	{
		private readonly IProductTypeRepository _ProductTypeRepository;
		public ProductTypeService(IProductTypeRepository productTypeRepository)
		{
			_ProductTypeRepository = productTypeRepository;
		}

		/// <summary>
		/// Gets all product types
		/// </summary>
		public async Task<IEnumerable<ProductType>> GetProductTypesAsync(){
			return await _ProductTypeRepository.GetProductTypes();
			
		}
	}

}
