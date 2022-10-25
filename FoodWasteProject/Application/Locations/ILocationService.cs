/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Interface of Location Service
 */

/* Project includes */
using Domain.Locations.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Locations
{
    public interface ILocationService
    {
        /// <summary>
        /// Gets all possible provinces from Costa Rica
        /// </summary>
        Task<IEnumerable<Province>> GetProvincesAsync();

        /// <summary>
        /// Gets all possible districts of certain province from Costa Rica
        /// </summary>
        /// <param name="Province"></param>
        Task<IEnumerable<District>> GetDistrictsAsync(string Province);

        /// <summary>
        /// Gets all possible towns of a certain province and district 
        /// from Costa Rica
        /// </summary>
        /// <param name="Province"></param>
        /// <param name="District"></param>
        Task<IEnumerable<Town>> GetTownsAsync(string Province, string District);
    }


}