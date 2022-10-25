//User's module - Core Dummpers
//Collaborators:
//-Álvaro Miranda
//-Nathan Miranda
//-Mariana Murillo
//-Emmanuel Zúñiga
//Summary: Interface of Administrator Service Interface

using Domain.Users.Entities;

namespace Application.Users.Implementations
{
    public interface IAdministratorService
    {
        /// <summary>
        /// Service to add an administrator to the client table in the database
        /// </summary>
        /// <param name="admin"></param>
        Task AddAdministratorAsync(Administrator admin);

        /// <summary>
        /// Get the administrator via the specific email
        /// </summary>
        /// <param name="email"></param>
        Task<Administrator?> GetAdministratorByEmail(string email);
        /// <summary>
        /// Get the administrator via the username
        /// </summary>
        /// <param name="userName"></param>
        Task<Administrator?> GetAdministratorByUserName(string userName);
    }
}
