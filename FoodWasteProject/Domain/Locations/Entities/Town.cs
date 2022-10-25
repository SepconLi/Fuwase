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
    public class Town
    {
        /**  Attributes **/
        public string Name { get; set; }
        public string PName { get; set; }
        public string DName { get; set; }


        /**  Methods **/

        // Basic constructor for Town
        public Town(string name, string pname, string dName)
        {
            Name = name;
            PName = pname;
            DName = dName;
        }

        // Empty constructor for EFCore
        public Town()
        {
            Name = "";
            PName = "";
            DName = "";
        }
    }
}
