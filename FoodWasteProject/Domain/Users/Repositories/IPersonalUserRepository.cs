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
using Domain.Users.Entities;
using Domain.Core.ValueObjects;
using Domain.Core.Repositories;

namespace Domain.Users.Repositories
{
	public interface IPersonalUserRepository : IRepository<PersonalUser>, IClientRepository
	{
		/// <summary>
		/// Returns a PersonalUser stored in the database with the specified email
		/// </summary>
		/// <param name="email"></param>
		Task<PersonalUser?> GetPersonalUserByEmail(string email);
		/// <summary>
		/// Returns a PersonalUser stored in the database with the specified IdNumber
		/// </summary>
		/// <param name="idNumber"></param>
		Task<PersonalUser?> GetPersonalUserByIdNumber(string idNumber);
		/// <summary>
		/// Returns a PersonalUser stored in the database with the specified email
		/// </summary>
		/// <param name="username"></param>
		Task<PersonalUser?> GetPersonalUserByUserName(string username);

	}
}
