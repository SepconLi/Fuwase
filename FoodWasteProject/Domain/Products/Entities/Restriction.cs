/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Restriction class
 *   Saves donation's dietary restrictions
 */

/* Project includes */
using Domain.Core.Entities;
using Domain.Donations.Entities;
using Domain.Core.ValueObjects;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Entities
{
    public class Restriction
    {
        /** Attributes **/
        public String FoodRestriction { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; private set; }

        /** Methods **/

        // Basic constructor for Restriction
        public Restriction (String foodRestriction)
        {
            FoodRestriction = foodRestriction;
            ProductId = 0;
            Product = null;
        }

        // Empty constructor for Restriction for EFCore
        public Restriction()
        {
            FoodRestriction = "";
            ProductId = 0;
            Product = null;
        }

        // Assigns the product to which the restriction belongs
        public void AssignProduct(Product product)
        {
            Product = product;
            if (Product != null)
            {
                ProductId = product.Id;
            }
        }
    }
}
