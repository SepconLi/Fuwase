/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of Client Repository
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
    internal class ClientRepository : UserRepository, IClientRepository
    {
        public ClientRepository(UsersDbContext unitOfWork) : base (unitOfWork)
        {
        }
        /// <summary>
        /// Returns a Client stored in the database with the specified email
        /// </summary>
        /// <param name="email"></param>
        public async Task<Client?> GetClientByEmail(string email)
        {
            IList<Client> userResult = await _dbContext.Clients.Where(e => e.Email == email).ToListAsync();
            Client? client = null;
            if (userResult.Length() > 0)
            {
                client = userResult.First();
            }
            return client;
        }
        /// <summary>
        /// Returns a Client stored in the database with the specified username
        /// </summary>
        /// <param name="username"></param>
        public async Task<Client?> GetClientByUserName(string username)
        {
            IList<Client> clients = await _dbContext.Clients.Where(e => e.UserName == username).ToListAsync();
            Client? client = null;
            if (clients.Length() > 0)
            {
                client = clients.First();
            }
            return client;
        }
        public async Task addStrike(string email)
        {
            Client client = _dbContext.Clients.Where(e => e.Email == email).First();
            if (client != null)
            {
                client.Strikes = client.Strikes + 1;
                _dbContext.Entry(client).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }

        }
    }
}
