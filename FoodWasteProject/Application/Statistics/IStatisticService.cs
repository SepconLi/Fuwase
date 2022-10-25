/* Statistic module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Interface of Statistic Service
 *   Calls infrastructure methods to add donation to database
 */

/* Project includes */
using Domain.Statistics.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Statistics
{
    public interface IStatisticService
    {
        /// <summary>
        /// Gets the statistics using the specified user_id
        /// </summary>
        /// <param name="user_id"></param>
        Task<Statistic?> GetStatisticsByUserIdAsync(string user_id);

        /// <summary>
		/// Returns the donation amount of the business profiles stored in the database
		/// </summary>
        Task<IEnumerable<Statistic>> GetTopBusinessDonors();

        /// <summary>
        /// Returns the donation amount of the app 
        /// </summary>
        Task<Statistic> GetTotalAppDonations();

        /// <summary>
        /// Returns the donation amount of each province
        /// </summary>
        Task<IEnumerable<ProvinceStats>> GetProvincesStats();

        /// <summary>
        /// Returns the ranking and the medal according to the user rank based in amount of donations done by the user
        /// Developer: Emmanuel Zúñiga Ch, Nathan Miranda.
        /// </summary>
        Task<(string, string)> GetUserRanking(string user_id);
    }
}