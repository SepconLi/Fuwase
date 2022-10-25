/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of BusinessUser Repository Interface
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Entities;
using Domain.Core.ValueObjects;
using Domain.Core.Repositories;
using System.Collections;

namespace Domain.Users.Repositories
{
	public interface IBusinessUserRepository : IRepository<BusinessUser>, IClientRepository
	{
		/// <summary>
		/// Returns a BusinessUser stored in the database with the specified email
		/// </summary>
		/// <param name="email"></param>
		Task<BusinessUser?> GetBusinessUserByEmail(string email);
		/// <summary>
		/// Returns a BusinessUser stored in the database with the specified IdNumber
		/// </summary>
		/// <param name="idNumber"></param>
		Task<BusinessUser?> GetBusinessUserByLegalDocument(string legalDocument);
		/// <summary>
		/// Returns a BusinessUser stored in the database with the specified email
		/// </summary>
		/// <param name="username"></param>
		Task<BusinessUser?> GetBusinessUserByUserName(string username);

		Task<IList<BusinessUser>?> GetUnverifiedAccounts(int status);
	}
}
