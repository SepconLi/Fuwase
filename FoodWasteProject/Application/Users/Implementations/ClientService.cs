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
using Domain.Users.Repositories;
using Domain.Users.Entities;

namespace Application.Users.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        /// <summary>
        /// Service to add a client to the client table in the database
        /// </summary>
        /// <param name="client"></param>
        public async Task AddClientAsync(Client client)
        {
            await _clientRepository.SaveAsync(client);
        }
        /// <summary>
        /// Get the client via the specific email
        /// </summary>
        /// <param name="email"></param>
        public async Task<Client?> GetClientByEmail(string email)
        {
            return await _clientRepository.GetClientByEmail(email);
        }
        /// <summary>
        /// Get the client via the username
        /// </summary>
        /// <param name="userName"></param>
        public async Task<Client?> GetClientByUserName(string username)
        {
            return await _clientRepository.GetClientByUserName(username);
        }
        public async Task addStrikeAsync(string email) 
        {
            await _clientRepository.addStrike(email);
        }
    }
}