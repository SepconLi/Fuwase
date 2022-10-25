/* CD-US-2.2 Forgot my password - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of ConfirmationCode class
 */
using Domain.Core.Repositories;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.Users.Repositories
{
    internal class ConfirmationCodeRepository : IConfirmationCodeRepository
    {
        protected readonly UsersDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ConfirmationCodeRepository(UsersDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        /// <summary>
         /// Search a ConfirmationCode (entity) for a certain email address.
         /// </summary>
         /// <param name="email"></param>
        public async Task<ConfirmationCode?> GetCodeByEmail(string email)
        {
            ConfirmationCode? confirmationCode = null;
            using (var transaction = new CommittableTransaction(new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                try
                {
                    var confirmationCodeResult = await _dbContext.ConfirmationCodes.FromSqlRaw($"EXEC getConfirmationCode @email",
                        new SqlParameter("email", email)).ToListAsync();
                    if (confirmationCodeResult.Length() > 0)
                    {
                        confirmationCode = confirmationCodeResult.First();
                    }
                    transaction.Commit();
                    return confirmationCode;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// Save a ConfirmationCode (entity).
        /// </summary>
        /// <param name="code"></param>
        public async Task SaveCodeAsync(ConfirmationCode code)
        {
            using (var transaction = new CommittableTransaction( new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                try
                {
                    System.FormattableString query = $"EXEC addConfirmationCode @email = {code.Email}, @code = {code.Code}, @id = {code.Id}";
                    _dbContext.Database.ExecuteSqlInterpolated(query);
                    await _dbContext.SaveEntitiesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }
        /// <summary>
        /// Delete a ConfirmationCode (entity) for a certain email address.
        /// </summary>
        /// <param name="email"></param>
        public async Task DeleteCodeForEmail(string email)
        {
            IList<ConfirmationCode> confirmationCodeResult = await _dbContext.ConfirmationCodes.Where(e => e.Email == email).ToListAsync();
            ConfirmationCode? confirmationCode = null;
            if (confirmationCodeResult.Length() > 0)
            {
                confirmationCode = confirmationCodeResult.First();
                _dbContext.ConfirmationCodes.Remove(confirmationCode);
                await _dbContext.SaveEntitiesAsync();
            }
        }
    }
}
