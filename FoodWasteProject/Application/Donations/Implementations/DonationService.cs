/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Donation's service
 */

/* Project includes */
using Domain.Core.Repositories;
using Domain.Donations.DTOs;
using Domain.Donations.Entities;
using Domain.Donations.Repositories;
using Domain.Products.Repositories;
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Donations.Implementations {
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;

        public DonationService(IDonationRepository donationRepository) {
            _donationRepository = donationRepository;
        }

        /// <summary>
        /// Adds given donation along with it's products and their restrictions
        /// </summary>
        /// <param name="donation"></param>
        public async Task AddDonationAsync(Donation donation) {
            await _donationRepository.AddDonationAsync(donation);
        }

        /// <summary>
        /// Gets donation using specified id
        /// </summary>
        /// <param name="id"></param>
        public async Task<Donation?> GetByIdAsync(int id)
        {
            return await _donationRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Gets all donations and their products as DonationDTOs
        /// </summary>
        public async Task<IEnumerable<DonationDTO>> GetAllDonationsWithProductsAsync() {
            return await _donationRepository.GetAllDonationsWithProductsAsync();
        }

        /// <summary>
        /// Gets all donations as DonationDTOs
        /// </summary>
        public async Task<IEnumerable<DonationDTO>> GetDonationAsync()
        {
            return await _donationRepository.GetAllAsync();
        }

        /// <summary>
        /// Modifies donation with new information
        /// </summary>
        /// <param name="donation"></param>
        public async Task ModifyDonationAsync(Donation donation)
        {
            await _donationRepository.ModifyDonationAsync(donation);
        }

        /// <summary>
        /// Gets donations associated with certain user
        /// </summary>
        /// <param name="userId"></param>
        public async Task<IEnumerable<DonationDTO>> GetDonationsByUserId(string userId)
        {
            return await _donationRepository.GetDonationsByUserId(userId);
        }

        /// <summary>
        /// Deletes donation with certain id
        /// </summary>
        /// <param name="Id"></param>
        public async Task HandleDonationDelete(int Id)
        {
            await _donationRepository.HandleDonationDelete(Id);
        }

        /// <summary>
        /// Sets the status of a specific donation associated with a given id
        /// Is called when the status of an Order and its products changes
        /// </summary>
        /// <param name="Id"></param>
        public async Task SetDonationStatusAsync(int donationId)
        {
            await _donationRepository.SetDonationStatusAsync(donationId);
        }

        // <summary>
        /// Retrieves amount of donations made for that campaign
        /// </summary>
        /// <param name="campaignId"></param>
        public async Task<int> GetDonationCountAsync(int campaignId)
        {
            return await _donationRepository.GetDonationCountAsync(campaignId);
        }
    }
}
