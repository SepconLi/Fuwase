//User's module - Core Dummpers
//Collaborators:
//-Álvaro Miranda
//-Nathan Miranda
//-Mariana Murillo
//-Emmanuel Zúñiga
//Summary: Interface of Administrator Service

using Domain.Users.Entities;
using Domain.Users.Repositories;

namespace Application.Users.Implementations
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository _adminRepository;
        public AdministratorService(IAdministratorRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        /// <summary>
        /// Service to add an administrator to the Administrator table in the database
        /// </summary>
        /// <param name="admin"></param>
        public async Task AddAdministratorAsync(Administrator admin)
        {
            await _adminRepository.SaveAsync(admin);
        }

        /// <summary>
        /// Get the administrator via the specific email
        /// </summary>
        /// <param name="email"></param>
        public async Task<Administrator?> GetAdministratorByEmail(string email)
        {
            return await _adminRepository.GetAdminByEmail(email);
        }
        /// <summary>
        /// Get the administrator via the username
        /// </summary>
        /// <param name="userName"></param>
        public async Task<Administrator?> GetAdministratorByUserName(string userName)
        {
            return await _adminRepository.GetAdminByUserName(userName);
        }
    }
}
