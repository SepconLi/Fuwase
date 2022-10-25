//User's module - Core Dummpers
//Collaborators:
//-Álvaro Miranda
//-Nathan Miranda
//-Mariana Murillo
//-Emmanuel Zúñiga
//Summary: Interface of Client Service

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Entities;

namespace Application.Users
{
    public interface IClientService
    {
        /// <summary>
        /// Service to add a client to the client table in the database
        /// </summary>
        /// <param name="client"></param>
        Task AddClientAsync(Client client);

        /// <summary>
        /// Get the client via the specific email
        /// </summary>
        /// <param name="email"></param>
        Task<Client?> GetClientByEmail(string email);
        /// <summary>
        /// Get the client via the username
        /// </summary>
        /// <param name="userName"></param>
        Task<Client?> GetClientByUserName(string userName);

        Task addStrikeAsync(string email);
    }
}
