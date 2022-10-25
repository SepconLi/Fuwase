//User's module - Core Dummpers
//Collaborators:
//-Álvaro Miranda
//-Nathan Miranda
//-Mariana Murillo
//-Emmanuel Zúñiga
//Summary: Interface of User Service

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Entities;

namespace Application.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Service to add an User to the User table in the database
        /// </summary>
        /// <param name="user"></param>
        Task AddUserAsync(User user);
        /// <summary>
        /// Get the User via the specific email
        /// </summary>
        /// <param name="email"></param>
        Task<User?> GetUserByEmail(string email);
        /// <summary>
        /// Get the User via the specific username
        /// </summary>
        /// <param name="username"></param>
        Task<User?> GetUserByUserName(string username);

        /// <summary>
        /// Updates the information of a user in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task UpdateUser(User user);
        /// <summary>
        /// Returns a User stored in the database with a certain HashedEmail
        /// </summary>
        /// <param name="hashedEmail"></param>
        /// <returns></returns>
        Task<User?> GetUserByHashedEmail(string hashedEmail);

        Task ChangeAnomPreference(User user);
    }
}

