/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of ProductType class
 *   Stores product types for display in product form.
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
    public class ProductType : AggregateRoot, IProductType
    {
        /**  Attributes **/
        public String Name { get; set; }

        /**  Methods **/

        // Basic constructor for ProductType
        public ProductType(String name) {
            Name = name;
        }

        // Empty constructor for EFCore
        public ProductType() {
            Name = "";
        }
    }
}
