/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of FoodType's service
 */

/* Project includes */
using Application.Products;
using Domain.Core.Repositories;
using Domain.Products.Repositories;
using Domain.Products.DTOs;
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Implementations
{
    public class FoodTypeService : IFoodTypeService
    {
        private readonly IFoodTypeRepository _FoodTypeRepository;

        public FoodTypeService(IFoodTypeRepository foodtypeRepository)
        {
            _FoodTypeRepository = foodtypeRepository;
        }

        /// <summary>
        /// Gets all food types to show in product form
        /// </summary>
        public async Task<IEnumerable<FoodTypeDTO>> GetAllFoodTypesAsync()
        {
            return await _FoodTypeRepository.GetAllFoodTypes();
        }
    }
}
