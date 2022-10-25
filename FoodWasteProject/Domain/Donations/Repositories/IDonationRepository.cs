/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Donation's interface for it's repository
 */

/* Project includes */
using Domain.Donations.DTOs;
using Domain.Donations.Entities;
using Domain.Core.Repositories;
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Donations.Repositories
{
    public interface IDonationRepository : IRepository<Donation>
    {
		/// <summary>
		/// Adds a donation to the database
		/// </summary>
		/// <param name="donation"></param>
		Task AddDonationAsync(Donation donation);

		/// <summary>
		/// Returns a Donation stored in the database that has the given id
		/// </summary>
		/// <param name="id"></param>
		Task<Donation?> GetByIdAsync(int id);

		/// <summary>
		/// Returns all Donations and their products stored in the database 
		/// as DonationDTOs
		/// </summary>
		Task<IEnumerable<DonationDTO>> GetAllDonationsWithProductsAsync();

		/// <summary>
		/// Returns all Donations stored in the database as DonationDTOs
		/// </summary>
		Task<IEnumerable<DonationDTO>> GetAllAsync();

		/// <summary>
		/// Modifies the specified Donation in the database
		/// </summary>
		/// <param name="donation"></param>
		Task ModifyDonationAsync(Donation donation);

		/// <summary>
		/// Returns all Donations stored in the database made by said user
		/// </summary>
		/// <param name="userId"></param>
		Task<IEnumerable<DonationDTO>> GetDonationsByUserId(string userId);

		/// <summary>
		/// Sets specified Donation's status in the database
		/// </summary>
		/// <param name="donationId"></param>
		Task SetDonationStatusAsync(int donationId);

		/// <summary>
		/// Deletes a Product from the database
		/// </summary>
		/// <param name="product"></param>
		Task DeleteProduct(Product product);

		/// <summary>
		/// Deletes a Donation from the database
		/// </summary>
		/// <param name="donation"></param>
		Task DeleteDonation(Donation donation);

		/// <summary>
		/// Deletes a Restriction from the database
		/// </summary>
		/// <param name="restriction"></param>
		Task DeleteRestriction(Restriction restriction);

		/// <summary>
		/// Saves changes to specified to donation to database
		/// </summary>
		/// <param name="donation"></param>
		Task SaveAsync(Donation donation);

		/// <summary>
		/// Handles deletion of specified Donation and it's associated entities
		/// </summary>
		/// <param name="Id"></param>
		Task HandleDonationDelete(int Id);

		// <summary>
		/// Retrieves amount of donations made for that campaign
		/// </summary>
		/// <param name="campaignId"></param>
		Task<int> GetDonationCountAsync(int campaignId);

	}
}
