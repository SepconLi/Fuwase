/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of FoodType class
 *   Stores food types for display in product form.
 */

namespace Domain.Products.Entities
{
    public class FoodType : IFoodType
    {
        /**  Attributes **/
        public String Name { get; }

        /**  Methods **/

        // Basic constructor for FoodType
        public FoodType(String name)
        {
            Name = name;
        }

        // Empty constructor for EFCore
        public FoodType()
        {
            Name = "";
        }
    }
}
