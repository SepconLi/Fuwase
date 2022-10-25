//User's module - Core Dummpers
//Collaborators:
//-Álvaro Miranda
//-Nathan Miranda
//-Mariana Murillo
//-Emmanuel Zúñiga
//Summary: Interface of PersonalUser Service


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Entities;

namespace Application.Users
{
    public interface IPersonalUserService
    {
        /// <summary>
        /// Service to add a PersonalUser to the PersonalUser table in the database
        /// </summary>
        /// <param name="p_user"></param>
        Task AddPersonalUserAsync(PersonalUser p_user);
        /// <summary>
        /// Get the personalUser via the specific email
        /// </summary>
        /// <param name="email"></param>
        Task<PersonalUser?> GetPersonalUserByEmail(string email);
        /// <summary>
        /// Get the personalUser via the specific idNumber
        /// </summary>
        /// <param name="idNumber"></param>
        Task<PersonalUser?> GetPersonalUserByIdNumber(string idNumber);
        /// <summary>
        /// Get the personalUser via the specific username
        /// </summary>
        /// <param name="username"></param>
        Task<PersonalUser?> GetPersonalUserByUserName(string username);


    }
}
