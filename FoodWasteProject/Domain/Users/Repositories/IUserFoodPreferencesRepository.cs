/* User's module - Imborrables
 * Collaboratos:
 * - Fabian Gonzalez
 * - Maeva Murcia
 * 
 * - Summary: Implementation of IUserFoodPreferencesRepository Repository Interface
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Entities;
using Domain.Core.ValueObjects;
using Domain.Core.Repositories;

namespace Domain.Users.Repositories
{
    public interface IUserFoodPreferencesRepository
    {
        Task SaveAsync(UserFoodPreferences userFoodPreferences);

        Task<IEnumerable<UserFoodPreferences?>> GetAllRestrictionsAsync(string userEmail);

        Task deleteAllRestrictionsPreferences(string userEmail);
    }
}
