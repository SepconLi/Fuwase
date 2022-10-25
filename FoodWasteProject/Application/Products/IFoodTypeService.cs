/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Interface of FoodType Service
 */

/* Project includes */
using Domain.Products.DTOs;
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products
{
    public interface IFoodTypeService
    {
        /// <summary>
        /// Gets all food types to show in product form
        /// </summary>
        Task<IEnumerable<FoodTypeDTO>> GetAllFoodTypesAsync();
    }
}
