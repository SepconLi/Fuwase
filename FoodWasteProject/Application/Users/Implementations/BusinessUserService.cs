//User's module - Core Dummpers
//Collaborators:
//-Álvaro Miranda
//-Nathan Miranda
//-Mariana Murillo
//-Emmanuel Zúñiga
//Summary: Implementation of BusinessUser Service

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Repositories;
using Domain.Users.Entities;

namespace Application.Users.Implementations
{
    public class BusinessUserService : IBusinessUserService
    {
        private readonly IBusinessUserRepository _businessUserRepository;
        public BusinessUserService(IBusinessUserRepository businessUserRepository)
        {
            _businessUserRepository = businessUserRepository;
        }
        /// <summary>
        /// Service to add a PersonalUser to the PersonalUser table in the database
        /// </summary>
        /// <param name="p_user"></param>
        public async Task AddBusinessUserAsync(BusinessUser b_user)
        {
            await _businessUserRepository.SaveAsync(b_user);
        }
        /// <summary>
        /// Get the personalUser via the specific email
        /// </summary>
        /// <param name="email"></param>
        public async Task<BusinessUser?> GetBusinessUserByEmail(string email)
        {
            return await _businessUserRepository.GetBusinessUserByEmail(email);
        }
        /// <summary>
        /// Get the personalUser via the specific idNumber
        /// </summary>
        /// <param name="idNumber"></param>
        public async Task<BusinessUser?> GetBusinessUserByLegalDocument(string legalDocument)
        {
            return await _businessUserRepository.GetBusinessUserByLegalDocument(legalDocument);
        }
        /// <summary>
        /// Get the personalUser via the specific username
        /// </summary>
        /// <param name="username"></param>
        public async Task<BusinessUser?> GetBusinessUserByUserName(string username)
        {
            return await _businessUserRepository.GetBusinessUserByUserName(username);
        }

        public async Task<IList<BusinessUser>?> GetUnverifiedAccounts(int status)
        {
            return await _businessUserRepository.GetUnverifiedAccounts(status);
        }
    }
}