/* User's module - Imborrables
 * Collaboratos:
 * - Fabian Gonzalez
 * - Maeva Murcia
 * 
 * - Summary: Implementation of IUserFoodPreferencesService
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Repositories;
using Domain.Users.Entities;

namespace Application.Users.Implementations
{
    public class UserFoodPreferencesService : IUserFoodPreferencesService
    {
        private readonly IUserFoodPreferencesRepository _userFoodPreferencesRepository;
        public UserFoodPreferencesService(IUserFoodPreferencesRepository userFoodPreferencesRepository)
        {
            _userFoodPreferencesRepository = userFoodPreferencesRepository;
        }

        public async Task AddUserFoodPreferencesAsync(UserFoodPreferences userFoodPreferences)
        {
            await _userFoodPreferencesRepository.SaveAsync(userFoodPreferences);
        }

        public async Task<IEnumerable<UserFoodPreferences?>> GetAllRestrictionsAsync(string userEmail)
        {
            return await _userFoodPreferencesRepository.GetAllRestrictionsAsync(userEmail);
        }

        public async Task deleteAllRestrictionsPreferences(string userEmail)
        {
            await _userFoodPreferencesRepository.deleteAllRestrictionsPreferences(userEmail);
        }
    }
}