/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Province class
 *   Stores all the province's information.
 */

/* Project includes */
using Domain.Core.Entities;

/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Locations.Entities
{
    public class Province
    {
        /**  Attributes **/
        public string Name { get; set; }

        /**  Methods **/

        // Empty constructor for EFCore
        public Province()
        {
            Name = "";
        }

        // Basic constructor for Province
        public Province(string name)
        {
            Name = name;
        }
    }
}
