/* Statistics module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Statistics class
 *   Stores all the province's total donations
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Statistics.Entities
{
    public class ProvinceStats
    {
        /**  Attributes **/

        public string Name { get; set; }
        public int Donations { get; set; }

        /** Methods **/

        public ProvinceStats(string name,int donations)
        {
            Name = name;
            Donations = donations;
        }

        public ProvinceStats()
        {
            Name = "";
            Donations = 0;
        }
    }
}
