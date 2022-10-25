//User's module - Core Dummpers
//Collaborators:
//-Álvaro Miranda
//-Nathan Miranda
//-Mariana Murillo
//-Emmanuel Zúñiga
//Summary: Interface of BusinessUser Service


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Entities;

namespace Application.Users
{
    public interface IBusinessUserService
    {
        /// <summary>
        /// Service to add a BusinessUser to the BusinessUser table in the database
        /// </summary>
        /// <param name="p_user"></param>
        Task AddBusinessUserAsync(BusinessUser b_user);
        /// <summary>
        /// Get the BusinessUser via the specific email
        /// </summary>
        /// <param name="email"></param>
        Task<BusinessUser?> GetBusinessUserByEmail(string email);
        /// <summary>
        /// Get the BusinessUser via the specific legalDocument
        /// </summary>
        /// <param name="idNumber"></param>
        Task<BusinessUser?> GetBusinessUserByLegalDocument(string legalDocument);
        /// <summary>
        /// Get the BusinessUser via the specific username
        /// </summary>
        /// <param name="username"></param>
        Task<BusinessUser?> GetBusinessUserByUserName(string username);

        Task<IList<BusinessUser>?> GetUnverifiedAccounts(int status);
    }
}
