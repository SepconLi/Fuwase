/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of User Repository Interface
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Domain.Core.Repositories;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users.Repositories
{
    internal class UserRepository : IUserRepository
    {
        protected readonly UsersDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public UserRepository(UsersDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        /// <summary>
        /// Inserts an User in the database and saves changes using a transaction
        /// </summary>
        /// <param name="user"></param>
        public async Task SaveAsync(User user)
        {
            using (var transaction = new CommittableTransaction(new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                try
                {
                    _dbContext.Add(user);
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
        /// Returns a User stored in the database with the specified email
        /// </summary>
        /// <param name="email"></param>
        public async Task<User?> GetUserByEmail(string email) 
        {
            IList<User> userResult = await _dbContext.Users.Where(e => e.Email == email).ToListAsync();
            User? user = null;
            if (userResult.Length() > 0)
            {
                user = userResult.First();
            }
            return user;
        }
        /// <summary>
        /// Returns a User stored in the database with the specified username
        /// </summary>
        /// <param name="username"></param>
        public async Task<User?> GetUserByUserName(string username)
        {
            IList<User> userResult = await _dbContext.Users.Where(e => e.UserName == username).ToListAsync();
            User? user = null;
            if (userResult.Length() > 0)
            {
                user = userResult.First();
            }
            return user;
        }
        /// <summary>
        /// Updates the information for a User in the database and saves changes
        /// </summary>
        /// <param name="user"></param>
        public async Task UpdateUser(User user)
        {
            _dbContext.Update(user);
            await _dbContext.SaveEntitiesAsync();
        }
        /// <summary>
        /// Validates the user credentials and returns the user with the specified email and password
        /// </summary>
        /// <param name="email"></param>
        /// <parm name="password"></parm>
        public async Task<User?> ValidateUserCredentials(string email, string password)
        {
            IList<User> userResult = await _dbContext.Users.Where(e => e.Email == email && e.Password == password).ToListAsync();
            User? user = null;
            if (userResult.Length() > 0)
            {
                user = userResult.First();
            }
            return user;
        }

        /// <summary>
        /// Returns a User stored in the database with the specified hashed email
        /// </summary>
        /// <param name="hashedEmail"></param>
        /// <returns></returns>
        public async Task<User?> GetUserByHashedEmail(string hashedEmail)
        {
            IList<User> userResult = await _dbContext.Users.Where(e => e.HashedEmail == hashedEmail).ToListAsync();
            User? user = null;
            if (userResult.Length() > 0)
            {
                user = userResult.First();
            }
            return user;
        }

        public async Task ChangeAnomPreference(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
