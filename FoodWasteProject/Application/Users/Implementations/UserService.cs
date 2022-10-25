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
using Domain.Users.Repositories;
using Domain.Users.Entities;

namespace Application.Users.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Service to add an User to the User table in the database
        /// </summary>
        /// <param name="user"></param>
        public async Task AddUserAsync(User user)
        {
            await _userRepository.SaveAsync(user);
        }
        /// <summary>
        /// Get the User via the specific email
        /// </summary>
        /// <param name="email"></param>
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }
        /// <summary>
        /// Get the User via the specific username
        /// </summary>
        /// <param name="username"></param>
        public async Task<User?> GetUserByUserName(string username)
        {
            return await _userRepository.GetUserByUserName(username);
        }
        
        /// <summary>
        /// Updates the information of a user in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task UpdateUser(User user) 
        {
            await _userRepository.UpdateUser(user);
        }


        /// <summary>
        /// Returns a User stored in the database with a certain HashedEmail
        /// </summary>
        /// <param name="hashedEmail"></param>
        /// <returns></returns>
        public async Task<User?> GetUserByHashedEmail(string hashedEmail)
        {
            return await _userRepository.GetUserByHashedEmail(hashedEmail);
        }
        public async Task ChangeAnomPreference(User user)
        {
            await _userRepository.ChangeAnomPreference(user);
        }
    }
}