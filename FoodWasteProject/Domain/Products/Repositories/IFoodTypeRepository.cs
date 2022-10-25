/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of FoodType's interface for it's repository
 */

/* Project includes */
using Domain.Products.Entities;
using Domain.Products.DTOs;
using Domain.Core.Repositories;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Repositories
{
    public interface IFoodTypeRepository
    {
        /// <summary>
		/// Returns food types stored in the database
		/// </summary>
        Task<IEnumerable<FoodTypeDTO>> GetAllFoodTypes();
    }
}
