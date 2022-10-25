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
using Domain.Users.Entities;
using Domain.Core.ValueObjects;
using Domain.Core.Repositories;

namespace Domain.Users.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Inserts an User in the database and saves changes
        /// </summary>
        /// <param name="user"></param>
        Task SaveAsync(User user);
        /// <summary>
        /// Returns a User stored in the database with the specified email
        /// </summary>
        /// <param name="email"></param>
        Task<User?> GetUserByEmail(string email);
        /// <summary>
        /// Returns a User stored in the database with the specified username
        /// </summary>
        /// <param name="username"></param>
        Task<User?> GetUserByUserName(string username);

        /// <summary>
        /// Updates the information for a User in the database and saves changes
        /// </summary>
        /// <param name="user"></param>
        Task UpdateUser(User user);

        /// <summary>
        /// Validates the user credentials and returns the user with the specified email and password
        /// </summary>
        /// <param name="email"></param>
        /// <parm name="password"></parm>
        Task<User?> ValidateUserCredentials(string email, string password);

        /// <summary>
        /// Returns a User stored in the database with the specified hashed Email
        /// </summary>
        /// <param name="hashedEmail"></param>
        /// <returns></returns>
        Task<User?> GetUserByHashedEmail(string hashedEmail);

        Task ChangeAnomPreference(User user);
    }
}
