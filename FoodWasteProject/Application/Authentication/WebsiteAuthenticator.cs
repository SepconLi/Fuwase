//User's module - Core Dummpers
//Collaborators:
//-Álvaro Miranda
//-Nathan Miranda
//-Mariana Murillo
//-Emmanuel Zúñiga
//Summary: Implementation of WebsiteAuthenticator an extension class of AuthenticationStateProvider

using System.Security.Claims;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using LanguageExt;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;

namespace Application.Authentication
{
    public class WebsiteAuthenticator : AuthenticationStateProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly ProtectedSessionStorage _protectedSessionStorage;

        public WebsiteAuthenticator(ProtectedSessionStorage protectedSessionStorage, IUserRepository userRepository)
        {
            _protectedSessionStorage = protectedSessionStorage;
            _userRepository = userRepository;
        }

        /// <summary>
        /// A task that, when resolved, gives an AuthenticationState instance that describes the current user.
        /// </summary>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var principal = new ClaimsPrincipal();

            try
            {
                var storedPrincipal = await _protectedSessionStorage.GetAsync<string>("identity");
                if (storedPrincipal.Success)
                {
                    var user = JsonConvert.DeserializeObject<User>(storedPrincipal.Value);
                    var CurrentUser = await LookUpUser(user.Email, user.Password);
                    var isLookUpSuccess = CurrentUser.Item2;
                    if (isLookUpSuccess)
                    {
                        var identity = CreateIdentityFromUser(user);
                        principal = new(identity);
                    }
                }
            }
            catch
            {

            }

            return new AuthenticationState(principal);
        }

        /// <summary>
        /// Checks if the user exists in the database and stores the user's data in the browser session store
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public async Task LoginAsync(string email, string password)
        {
            var CurrentUser = await LookUpUser(email, password);
            var userInDatabase = CurrentUser.Item1;
            var isSuccess = CurrentUser.Item2;
            var principal = new ClaimsPrincipal();

            if (isSuccess)
            {
                var identity = CreateIdentityFromUser(userInDatabase!);
                principal = new ClaimsPrincipal(identity);
                await _protectedSessionStorage.SetAsync("identity", JsonConvert.SerializeObject(userInDatabase));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }
        /// <summary>
        /// Delete the user's data from the browser session store
        /// </summary>
        public async Task LogoutAsync()
        {
            await _protectedSessionStorage.DeleteAsync("identity");
            var principal = new ClaimsPrincipal();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        /// <summary>
        /// Creates a new claim and role to the user
        /// </summary>
        /// <param name="user"></param>
        private ClaimsIdentity CreateIdentityFromUser(User user)
        {
            var result =  new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.Name, user.Email),
                new (ClaimTypes.Hash, user.Password),
            }, "Authorized User");

            //Get the user role and add a claim to the identity
            var roles = user.Role;
            //According to the PO users can only have one role
            result.AddClaim(new (ClaimTypes.Role, roles));

            return result;
        }

        /// <summary>
        /// Look up the user with the email and password in the database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        private async Task<(User?, bool)> LookUpUser(string email, string password)
        {
            User? result =  await _userRepository.ValidateUserCredentials(email, password);
            return (result, result is not null);
        }
    }
}
