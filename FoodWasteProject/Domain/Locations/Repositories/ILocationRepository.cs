/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Location's interface for it's repository
 */

/* Project includes */
using Domain.Locations.Entities;
using Domain.Core.Repositories;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Locations.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        /// <summary>
		/// Returns all Provinces stored in the database
		/// </summary>
        Task<IEnumerable<Province>> GetProvinces();

        /// <summary>
		/// Returns all Districts stored in the database that belong to a 
        /// certain province
		/// </summary>
		/// <param name="pname"></param>
        Task<IEnumerable<District>> GetDistricts(string pname);

        /// <summary>
		/// Returns all Town stored in the database that belong to a certain
        /// province and district
		/// </summary>
		/// <param name="donation"></param>
        Task<IEnumerable<Town>> GetTowns(string pname,string dname);
    }
}
