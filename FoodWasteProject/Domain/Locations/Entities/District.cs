/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of District class
 *   Stores all the district's information.
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
    public class District
    {
        /**  Attributes **/
        public string Name { get; set; }
        public string PName { get; set; }

        /**  Methods **/

        // Basic constructor for District
        public District(string name,string pname)
        {
            Name = name;
            PName = pname;
        }

        // Empty constructor for EFCore
        public District()
        {
            Name = "";
            PName = "";
        }
    }
}
