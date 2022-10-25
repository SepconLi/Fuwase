/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of FoodType class' DTO
 *   Stores the food type's name for read only access.
 */

/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.DTOs
{
    public class FoodTypeDTO
    {
        /**  Attributes **/
        public String Name { get; }

        /**  Methods **/
        public FoodTypeDTO(String name)
        {
            Name = name;
        }
    }
}
