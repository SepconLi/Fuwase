/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Allergen class
 *   Stores allergen names and information for display in product form.
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
    public class Allergen : AggregateRoot
    {
        /**  Attributes **/
        public String Name { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }

        /**  Methods **/

        // Basic constructor for Allergen
        public Allergen(String name, String description, String category) {
            Name = name;
            Description = description;
            Category = category;
        }

        // Empty constructor for EFCore
        public Allergen() {
            Name = "";
            Description = "";
            Category = "";
        }
    }
}
