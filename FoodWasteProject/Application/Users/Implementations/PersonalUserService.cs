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
using Domain.Users.Repositories;
using Domain.Users.Entities;

namespace Application.Users.Implementations
{
    public class PersonalUserService : IPersonalUserService
    {
        private readonly IPersonalUserRepository _personalUserRepository;
        public PersonalUserService(IPersonalUserRepository personalUserRepository)
        {
            _personalUserRepository = personalUserRepository;
        }
        /// <summary>
        /// Service to add a PersonalUser to the PersonalUser table in the database
        /// </summary>
        /// <param name="p_user"></param>
        public async Task AddPersonalUserAsync(PersonalUser p_user)
        {
            await _personalUserRepository.SaveAsync(p_user);
        }
        /// <summary>
        /// Get the personalUser via the specific email
        /// </summary>
        /// <param name="email"></param>
        public async Task<PersonalUser?> GetPersonalUserByEmail(string email)
        {
            return await _personalUserRepository.GetPersonalUserByEmail(email);
        }
        /// <summary>
        /// Get the personalUser via the specific idNumber
        /// </summary>
        /// <param name="idNumber"></param>
        public async Task<PersonalUser?> GetPersonalUserByIdNumber(string idnumber)
        {
            return await _personalUserRepository.GetPersonalUserByIdNumber(idnumber);
        }
        /// <summary>
        /// Get the personalUser via the specific username
        /// </summary>
        /// <param name="username"></param>
        public async Task<PersonalUser?> GetPersonalUserByUserName(string username)
        {
            return await _personalUserRepository.GetPersonalUserByUserName(username);
        }
    }
}