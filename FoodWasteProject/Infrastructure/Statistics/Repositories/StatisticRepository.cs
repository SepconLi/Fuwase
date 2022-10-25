/* Statistic module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Statistic's repository
 */

/* Project includes */
using Domain.Core.Repositories;
using Domain.Statistics.Entities;
using Domain.Statistics.Repositories;
using Microsoft.Data.SqlClient;
/* System includes */
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Statistics.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {

        private readonly StatisticDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public StatisticRepository(StatisticDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<Statistic?> GetStatisticsByUserIdAsync(string user_id)
        {
            IList<Statistic> statistics = await _dbContext.Statistics.Where(e => e.User_Id == user_id).ToListAsync();
            Statistic? statistic = null;
            if (statistics.Length() > 0)
            {
                statistic = statistics.First();
            }
            return statistic;
        }

        /// <summary>
        /// Returns the donation amount of the business profiles stored in the database
        /// </summary>
        public async Task<Statistic> GetTotalAppDonations()
        {
            var total = await _dbContext.Statistics.FromSqlRaw($"EXEC get_total_app_donations").ToListAsync();
            return total.First();
        }
        /// <summary>
        /// Returns the donation amount of the business profiles stored in the database
        /// </summary>
        public async Task<IEnumerable<Statistic>> GetTopBusinessDonors()
        {
            var _top_business = await _dbContext.Statistics.FromSqlRaw($"EXEC get_top_business_donors").ToListAsync();
            return _top_business;
        }

        /// <summary>
        /// Returns the donation amount of each province
        /// </summary>
        public async Task<IEnumerable<ProvinceStats>> GetProvincesStats() {
            var _donations = await _dbContext.Provinces.FromSqlRaw($"EXEC GetProvincesStats").ToListAsync();
            return _donations;
        }
    }

}