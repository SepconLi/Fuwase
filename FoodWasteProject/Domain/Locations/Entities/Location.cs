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
    public class Location : AggregateRoot
    {
        /**  Attributes **/
        public string Name { get; }
        public string? PName { get; }
        public string? DName { get; }

        /**  Methods **/

        // Empty constructor for EFCore
        public Location()
        {
            Name = "";
            PName = "";
            DName = "";
        }

        // Basic constructor for Location
        public Location(string name, string? pname, string? dName)
        {
            Name = name;
            PName = pname;
            DName = dName;
        }
    }
}
