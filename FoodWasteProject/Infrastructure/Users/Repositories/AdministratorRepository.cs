/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of Administrator Repository
 */

using Domain.Users.Entities;
using Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users.Repositories
{
    internal class AdministratorRepository : UserRepository, IAdministratorRepository
    {
        public AdministratorRepository(UsersDbContext unitOfWork) : base(unitOfWork)
        {
        }
        /// <summary>
        /// Returns an Administrator stored in the database with the specified email
        /// </summary>
        /// <param name="email"></param>
        public async Task<Administrator?> GetAdminByEmail(string email)
        {
            IList<Administrator> userResult = await _dbContext.Administrators.Where(e => e.Email == email).ToListAsync();
            Administrator? admin= null;
            if (userResult.Length() > 0)
            {
                admin = userResult.First();
            }
            return admin;
        }
        /// <summary>
        /// Returns an Administrator stored in the database with the specified username
        /// </summary>
        /// <param name="username"></param>
        public async Task<Administrator?> GetAdminByUserName(string username)
        {
            IList<Administrator> adminResult = await _dbContext.Administrators.Where(e => e.UserName == username).ToListAsync();
            Administrator? admin = null;
            if (adminResult.Length() > 0)
            {
                admin = adminResult.First();
            }
            return admin;
        }
    }
}
