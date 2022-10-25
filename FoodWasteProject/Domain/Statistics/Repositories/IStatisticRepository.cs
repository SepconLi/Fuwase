/* Statistics module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of statistics interface for it's repository
 */

/* Project includes */
using Domain.Statistics.Entities;
using Domain.Core.Repositories;

/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Statistics.Repositories
{
    public interface IStatisticRepository
    {
		/// <summary>
		/// Returns the statistics stored in the database that has the given user id
		/// </summary>
		/// <param name="user_id"></param>
		Task<Statistic?> GetStatisticsByUserIdAsync(string user_id);

		/// <summary>
		/// Returns the donation amount of the business profiles stored in the database
		/// </summary>
		Task<IEnumerable<Statistic>> GetTopBusinessDonors();

		/// <summary>
		/// Returns the amount of all the donations
		/// </summary>
		Task<Statistic> GetTotalAppDonations();

		/// <summary>
		/// Returns the donation amount of each province
		/// </summary>
		Task<IEnumerable<ProvinceStats>> GetProvincesStats();
	}
}
