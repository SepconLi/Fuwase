/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of FoodType's repository
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
    internal class FoodTypeRepository : IFoodTypeRepository
    {
        private readonly ProductDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public FoodTypeRepository(ProductDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
		/// Returns food types stored in the database
		/// </summary>
        public async Task<IEnumerable<FoodTypeDTO>> GetAllFoodTypes()
        {
            List<FoodTypeDTO> foodtypes = await _dbContext.FoodTypes
                .Select(t => new FoodTypeDTO(t.Name)).ToListAsync();
            foodtypes.Add(new FoodTypeDTO("Otro"));
            foodtypes.RemoveAt(6);
            return foodtypes;
        }
    }
}
