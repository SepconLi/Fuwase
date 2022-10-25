/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of PersonalUser Repository Interface
 */
using System;
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
	internal class PersonalUserRepository : ClientRepository, IPersonalUserRepository
	{
		public PersonalUserRepository(UsersDbContext unitOfWork) : base(unitOfWork)
		{
		}
        /// <summary>
		/// Returns a PersonalUser stored in the database with the specified email
		/// </summary>
		/// <param name="email"></param>
        public async Task<PersonalUser?> GetPersonalUserByEmail(string email)
        {
            IList<PersonalUser> personal_users = await _dbContext.PersonalUsers.Where(e => e.Email == email).ToListAsync();
            PersonalUser? personalUser = null;
            if (personal_users.Length() > 0)
            {
                personalUser = personal_users.First();
            }
            return personalUser;
        }
        /// <summary>
		/// Returns a PersonalUser stored in the database with the specified IdNumber
		/// </summary>
		/// <param name="idNumber"></param>
        public async Task<PersonalUser?> GetPersonalUserByIdNumber(string idnumber)
        {
            IList<PersonalUser> personal_users = await _dbContext.PersonalUsers.Where(e => e.IdNumber == idnumber).ToListAsync();
            PersonalUser? personalUser = null;
            if (personal_users.Length() > 0)
            {
                personalUser = personal_users.First();
            }
            return personalUser;
        }
        /// <summary>
		/// Returns a PersonalUser stored in the database with the specified email
		/// </summary>
		/// <param name="username"></param>
        public async Task<PersonalUser?> GetPersonalUserByUserName(string username)
        {
            IList<PersonalUser> personal_users = await _dbContext.PersonalUsers.Where(e => e.UserName == username).ToListAsync();
            PersonalUser? personalUser = null;
            if (personal_users.Length() > 0)
            {
                personalUser = personal_users.First();
            }
            return personalUser;

        }

    }
}
