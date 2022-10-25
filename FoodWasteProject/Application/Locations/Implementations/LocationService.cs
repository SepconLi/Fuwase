/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Location's service
 */

/* Project includes */
using Application.Locations;
using Domain.Core.Repositories;
using Domain.Locations.Repositories;
using Domain.Locations.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Locations.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _LocationRepository;

        public LocationService(ILocationRepository LocationRepository)
        {
            _LocationRepository = LocationRepository;
        }

        /// <summary>
        /// Gets all possible provinces from Costa Rica
        /// </summary>
        public async Task<IEnumerable<Province>> GetProvincesAsync() {
            return await _LocationRepository.GetProvinces();
        }

        /// <summary>
        /// Gets all possible districts of certain province from Costa Rica
        /// </summary>
        /// <param name="Province"></param>
        public async Task<IEnumerable<District>> GetDistrictsAsync(string Province) {
            return await _LocationRepository.GetDistricts(Province);
        }

        /// <summary>
        /// Gets all possible towns of a certain province and district 
        /// from Costa Rica
        /// </summary>
        /// <param name="Province"></param>
        /// <param name="District"></param>
        public async Task<IEnumerable<Town>> GetTownsAsync(string Province, string District) {
            return await _LocationRepository.GetTowns(Province, District);
        }
    }
}
