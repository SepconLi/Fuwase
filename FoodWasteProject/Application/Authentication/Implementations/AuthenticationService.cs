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
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Domain.Users.Entities;
using Newtonsoft.Json;

namespace Application.Authentication.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ProtectedSessionStorage _protectedSessionStorage;
        public string? user_email;
        ProtectedBrowserStorageResult<string> UserData = new();
        public AuthenticationService(ProtectedSessionStorage protectedSessionStorage)
        {
            _protectedSessionStorage = protectedSessionStorage;
        }

        /// <summary>
        /// Returns the browser session storage data about the current user's identity
        /// </summary>
        public async Task GetValueAsync()
        {
            ProtectedBrowserStorageResult<string> result = new();

            try
            {
                result = await _protectedSessionStorage.GetAsync<string>("identity"); 
                UserData = result;
            }
            catch
            {
            }
            finally
            {
                user_email = result.Success ? result.Value : "Not success.";
            }
        }
        /// <summary>
        /// Returns the actual authentified user Email
        /// </summary>
        public async Task<string?> GetLoggedUserEmail()
        {
            var user = JsonConvert.DeserializeObject<PersonalUser>(UserData.Value!);
            return user!.Email;

        }
        /// <summary>
        /// Returns the actual authentified user UserName
        /// </summary>
        public async Task<string?> GetCurrentUserName()
        {
            var user = JsonConvert.DeserializeObject<PersonalUser>(UserData.Value!);
            return user!.UserName;
        }

    }
}
