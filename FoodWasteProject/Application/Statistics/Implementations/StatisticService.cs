/* Statistic module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Statistic's service
 */

/* Project includes */
using Domain.Statistics.Entities;
using Domain.Statistics.Repositories;

namespace Application.Statistics.Implementations {
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticRepository _statisticRepository;

        public StatisticService(IStatisticRepository statisticRepository) {
            _statisticRepository = statisticRepository;
        }

       
        /// <summary>
        /// Gets statistic using specified id
        /// </summary>
        /// <param name="user_id"></param>
        public async Task<Statistic?> GetStatisticsByUserIdAsync(string user_id)
        {
            return await _statisticRepository.GetStatisticsByUserIdAsync(user_id);
        }

        /// <summary>
        /// Returns the donation amount of the business profiles stored in the database
        /// </summary>
        public async Task<IEnumerable<Statistic>> GetTopBusinessDonors()
        {
            return await _statisticRepository.GetTopBusinessDonors();
        }

        /// <summary>
        /// Returns the total amount of donations made in the app
        /// </summary>
        public async Task<Statistic> GetTotalAppDonations()
        {
            return await _statisticRepository.GetTotalAppDonations();
        }

        /// <summary>
        /// Returns the donation amount of each province
        /// </summary>
        public async Task<IEnumerable<ProvinceStats>> GetProvincesStats() { 
            return await _statisticRepository.GetProvincesStats();
        }

        /// <summary>
        /// Returns the ranking and the medal according to the user rank based in amount of donations done by the user
        /// Developer: Emmanuel Zúñiga Ch, Nathan Miranda.
        /// </summary>
        public async Task<(string, string)> GetUserRanking(string user_id)
        {
            Statistic? statistics = await _statisticRepository.GetStatisticsByUserIdAsync(user_id);
            string? rank;
            string? rankMedal;
            if (statistics.Donation_Amount == 0)
            {
                rank = null;
                rankMedal = null;
            } else if (statistics.Donation_Amount >= 1 && statistics.Donation_Amount <= 5){
                rank = "Bronce";
                rankMedal = "../images/bronze-medal.png";
            }
            else if (statistics.Donation_Amount >= 6 && statistics.Donation_Amount <= 10){
                rank = "Plata";
                rankMedal = "../images/silver-medal.png";
            }
            else if (statistics.Donation_Amount >= 11 && statistics.Donation_Amount <= 15){
                rank = "Oro";
                rankMedal = "../images/gold-medal.png";
            }
            else if (statistics.Donation_Amount >= 16 && statistics.Donation_Amount <= 25){
                rank = "Platino";
                rankMedal = "../images/platinum-medal.png";
            }
            else
            {
                rank = "Diamante";
                rankMedal = "../images/diamond-medal.png";
            }
            return (rank, rankMedal);
        }

    }
}
