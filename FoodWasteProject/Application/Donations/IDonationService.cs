/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Interface of Donation Service
 *   Calls infrastructure methods to add donation to database
 */

/* Project includes */
using Domain.Donations.DTOs;
using Domain.Donations.Entities;
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Donations
{
    public interface IDonationService
    {
        /// <summary>
        /// Adds given donation along with it's products and their restrictions
        /// </summary>
        /// <param name="donation"></param>
        Task AddDonationAsync(Donation donation);

        /// <summary>
        /// Gets donation using specified id
        /// </summary>
        /// <param name="id"></param>
        Task<Donation?> GetByIdAsync(int id);

        /// <summary>
        /// Gets all donations and their products as DonationDTOs
        /// </summary>
        Task<IEnumerable<DonationDTO>> GetAllDonationsWithProductsAsync();

        /// <summary>
        /// Gets all donations as DonationDTOs
        /// </summary>
        Task<IEnumerable<DonationDTO>> GetDonationAsync();

        /// <summary>
        /// Modifies donation with new information
        /// </summary>
        /// <param name="donation"></param>
        Task ModifyDonationAsync(Donation donation);

        /// <summary>
        /// Gets donations associated with certain user
        /// </summary>
        /// <param name="userId"></param>
        Task<IEnumerable<DonationDTO>> GetDonationsByUserId(string userId);

        /// <summary>
        /// Deletes donation with certain id
        /// </summary>
        /// <param name="Id"></param>
        Task HandleDonationDelete(int Id);

        /// <summary>
        /// Sets the status of a specific donation associated with a given id
        /// Is called when the status of an Order and its products changes
        /// </summary>
        /// <param name="Id"></param>
        Task SetDonationStatusAsync(int donationId);

        // <summary>
        /// Retrieves amount of donations made for that campaign
        /// </summary>
        /// <param name="campaignId"></param>
        Task<int> GetDonationCountAsync(int campaignId);
    }
}