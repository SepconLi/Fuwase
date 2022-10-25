/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Donation's repository
 */

/* Project includes */
using Domain.Core.Repositories;
using Domain.Donations.DTOs;
using Domain.Donations.Entities;
using Domain.Donations.Repositories;
using Domain.Products.Entities;
using Microsoft.Data.SqlClient;
using Domain.Products.Repositories;
/* System includes */
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.Donations.Repositories {
    internal class DonationRepository : IDonationRepository {

        private readonly DonationDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public DonationRepository(DonationDbContext unitOfWork) {
            _dbContext = unitOfWork;
        }

        /// <summary>
		/// Adds a donation to the database
		/// </summary>
		/// <param name="donation"></param>
        public async Task AddDonationAsync(Donation donation) {
            using (var transaction = new CommittableTransaction(
                       new TransactionOptions { 
                           IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                try
                {
                    _dbContext.Donations.Add(donation);
                    await _dbContext.SaveEntitiesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        /// <summary>
		/// Returns a Donation stored in the database that has the given id
		/// </summary>
		/// <param name="id"></param>
        public async Task<Donation?> GetByIdAsync(int id) {
            return await _dbContext.Donations
                .Include(d => d.Products.Where(p => p.Quantity > 0))
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        /// <summary>
		/// Returns all Donations and their products stored in the database 
		/// as DonationDTOs
		/// </summary>
        public async Task<IEnumerable<DonationDTO>> GetAllDonationsWithProductsAsync()
        {
            //TODO: Change the status name to "Disponible" when a donation is requested.
            return await _dbContext.Donations.Where(d=> d.Status == "A") 
                .Select(
                t => new DonationDTO(
                    t.Id, t.DonorId,
                    // List of donation's products
                    _dbContext.Products
                    .Where(p => p.DonationId == t.Id && p.Quantity > 0)
                    .Select(
                        p => new Product(p.Id, p.Name, p.FoodType, p.ProductType, 
                            p.ExpirationDate, p.Quantity, p.Weight, p.Donation,
                            p.Image!, p.Brand!, p.Restrictions.ToList(), p.DonationId)
                    ).ToList()
                )
            ).ToListAsync();
        }

        /// <summary>
		/// Returns all Donations stored in the database as DonationDTOs
		/// </summary>
        public async Task<IEnumerable<DonationDTO>> GetAllAsync()
        {
            return await _dbContext.Donations.Where(d=> d.Status == "A").
                Select(t => new DonationDTO(t.Id,t.DonorId, t.Status, t.Province, 
                t.County, t.District, t.ExactLocation, t.CreationDate
                , t.Description)).
                ToListAsync();
        }

        /// <summary>
		/// Modifies the specified Donation in the database
		/// </summary>
		/// <param name="donation"></param>
        public async Task ModifyDonationAsync(Donation donation) {
            _dbContext.Update(donation);
            await _dbContext.SaveEntitiesAsync();
        }

        /// <summary>
		/// Returns all Donations stored in the database made by said user
		/// </summary>
		/// <param name="userId"></param>
        public async Task<IEnumerable<DonationDTO>> GetDonationsByUserId(string userId)
        {
            return await _dbContext.Donations
                .Where(t => t.DonorId == userId)
                .Select(
                    t => new DonationDTO(t.Id,t.DonorId, t.Status, t.CreationDate,
                    t.Products.ToList(), t.Description))
                .ToListAsync()
                ;
        }

        /// <summary>
		/// Sets specified Donation's status in the database
		/// </summary>
		/// <param name="donationId"></param>
        public async Task SetDonationStatusAsync(int donationId)
        {
            await _dbContext.Database.ExecuteSqlRawAsync($"EXEC SetDonationStatus @DonationId", new SqlParameter("DonationId", donationId));
            _dbContext.ChangeTracker.Clear();
        }

        // <summary>
        /// Retrieves amount of donations made for that campaign
        /// </summary>
        /// <param name="campaignId"></param>
        public async Task<int> GetDonationCountAsync(int campaignId)
        {
            return await _dbContext.Database.ExecuteSqlRawAsync($"EXEC GetCampaignDonationAmount @campaignId", new SqlParameter("campaignId", campaignId));
        }

        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="product"></param>
        public Task DeleteProduct(Product product)
        {
            _dbContext.Remove(product);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        /// <summary>
		/// Deletes a Donation from the database
		/// </summary>
		/// <param name="donation"></param>
        public Task DeleteDonation(Donation donation)
        {
            _dbContext.Remove(donation);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        /// <summary>
		/// Deletes a Restriction from the database
		/// </summary>
		/// <param name="restriction"></param>
        public Task DeleteRestriction(Restriction restriction)
        {
            _dbContext.Remove(restriction);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        /// <summary>
		/// Saves changes to specified to donation to database
		/// </summary>
		/// <param name="donation"></param>
        public async Task SaveAsync(Donation donation)
        {
            _dbContext.Update(donation);
            await _dbContext.SaveEntitiesAsync();
        }

        /// <summary>
		/// Handles deletion of specified Donation and it's associated entities
		/// </summary>
		/// <param name="Id"></param>
        public async Task HandleDonationDelete(int Id)
        {
            Donation donation = await GetByIdAsync(Id);
            if (donation != null)
            {
                await DeleteDonation(donation);
                donation = null;
            }
        }

    }
}
