//User's module - Core Dummpers
//Collaborators:
//-Álvaro Miranda
//-Nathan Miranda
//-Mariana Murillo
//-Emmanuel Zúñiga
//Summary: Interface of Authentication Service


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Authentication
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Returns the browser session storage data about the current user's identity
        /// </summary>
        Task GetValueAsync();
        /// <summary>
        /// Returns the actual authentified user Email
        /// </summary>
        Task<string?> GetLoggedUserEmail();
        /// <summary>
        /// Returns the actual authentified user UserName
        /// </summary>
        Task<string?> GetCurrentUserName();
    }
}
