/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of Administrator Repository Interface
 */
using Domain.Core.Repositories;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users.Repositories
{
    public interface IAdministratorRepository : IRepository<Administrator>, IUserRepository
    {
        /// <summary>
        /// Returns an Administrator stored in the database with the specified email
        /// </summary>
        /// <param name="email"></param>
        Task<Administrator?> GetAdminByEmail(string email);
        /// <summary>
        /// Returns an Administrator stored in the database with the specified username
        /// </summary>
        /// <param name="username"></param>
        Task<Administrator?> GetAdminByUserName(string username);
    }
}
