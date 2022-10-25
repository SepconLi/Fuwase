/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of BusinessUser Repository
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Repositories;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users.Repositories
{
    internal class BusinessUserRepository : ClientRepository, IBusinessUserRepository
    {
        public BusinessUserRepository(UsersDbContext unitOfWork) : base(unitOfWork)
        {
        }
        /// <summary>
        /// Returns a BusinessUser stored in the database with the specified email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<BusinessUser?> GetBusinessUserByEmail(string email)
        {
            IList<BusinessUser> business_users = await _dbContext.BusinessUsers.Where(e => e.Email == email).ToListAsync();
            BusinessUser? businessUser = null;
            if (business_users.Length() > 0)
            {
                businessUser = business_users.First();
            }
            return businessUser;
        }
        /// <summary>
        /// Returns a BusinessUser stored in the database with the specified LegalDocument
        /// </summary>
        /// <param name="legalDocument"></param>
        /// <returns></returns>
        public async Task<BusinessUser?> GetBusinessUserByLegalDocument(string legalDocument)
        {
            IList<BusinessUser> business_users = await _dbContext.BusinessUsers.Where(e => e.Legal_Document == legalDocument).ToListAsync();
            BusinessUser? businessUser = null;
            if (business_users.Length() > 0)
            {
                businessUser = business_users.First();
            }
            return businessUser;
        }
        /// <summary>
        /// Returns a BusinessUser stored in the database with the specified email
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<BusinessUser?> GetBusinessUserByUserName(string username)
        {
            IList<BusinessUser> business_users = await _dbContext.BusinessUsers.Where(e => e.UserName == username).ToListAsync();
            BusinessUser? businessUser = null;
            if (business_users.Length() > 0)
            {
                businessUser = business_users.First();
            }
            return businessUser;
        }

        public async Task<IList<BusinessUser>?> GetUnverifiedAccounts(int status) 
        {
            IList<BusinessUser> business_users = await _dbContext.BusinessUsers.Where(e => e.Status == status).ToListAsync();
            return business_users;
        }
    }
}
