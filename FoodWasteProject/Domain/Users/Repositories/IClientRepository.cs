/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of Client Repository Interface
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
    public interface IClientRepository : IRepository<Client>, IUserRepository
    {
        /// <summary>
        /// Returns a Client stored in the database with the specified email
        /// </summary>
        /// <param name="email"></param>
        Task<Client?> GetClientByEmail(string email);
        /// <summary>
        /// Returns a Client stored in the database with the specified username
        /// </summary>
        /// <param name="username"></param>
        Task<Client?> GetClientByUserName(string username);

        Task addStrike(string email);
    }
}
