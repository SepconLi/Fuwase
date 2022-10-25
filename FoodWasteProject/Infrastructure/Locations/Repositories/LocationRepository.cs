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
using Domain.Core.Repositories;
using Domain.Locations.Entities;
using Domain.Locations.Repositories;
using Infrastructure.Locations;
/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Locations.Repositories
{
    internal class LocationRepository : ILocationRepository
    {

        private readonly LocationDBContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public LocationRepository(LocationDBContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
		/// Returns all Provinces stored in the database
		/// </summary>
        public async Task<IEnumerable<Province>> GetProvinces() {
            var _provinces = await _dbContext.Provinces.FromSqlRaw($"EXEC getProvinces").ToListAsync();
            return _provinces;
        }

        /// <summary>
		/// Returns all Districts stored in the database that belong to a 
        /// certain province
		/// </summary>
		/// <param name="pname"></param>
        public async Task<IEnumerable<District>> GetDistricts(string province) {
            var _districts = await _dbContext.Districts.FromSqlRaw($"EXEC getCountys @province",
            new SqlParameter("@province", province)).ToListAsync();
            return _districts;
        }

        /// <summary>
		/// Returns all Town stored in the database that belong to a certain
        /// province and district
		/// </summary>
		/// <param name="donation"></param>
        public async Task<IEnumerable<Town>> GetTowns(string pname, string dname) {
            var _towns = await _dbContext.Towns.FromSqlRaw($"EXEC getDistricts @province, @county",
                new SqlParameter("province",pname),
                new SqlParameter("county",dname)).ToListAsync();
            return _towns;
        }
    }
}
