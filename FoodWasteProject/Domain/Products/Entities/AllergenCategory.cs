/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of AllergenCategory class
 *   Stores allergen categories' information for display in product form.
 */

/* Project includes */
using Domain.Core.Entities;
using Domain.Core.ValueObjects;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Entities
{
    public class AllergenCategory : AggregateRoot
    {
        /**  Attributes **/
        public String Name { get; set; }
        public String Icon { get; set; }

        /**  Methods **/

        // Basic constructor for AllergenCategory
        public AllergenCategory(String name, String icon)
        {
            Name = name;
            Icon = icon;
        }

        // Empty constructor for EFCore
        public AllergenCategory()
        {
            Name = "";
            Icon = "";
        }
    }
}
