/* User's module - Imborrables
 * Collaboratos:
 * - Fabian Gonzalez
 * - Maeva Murcia
Summary: Interface of UserFoodPreferencesService Service
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Entities;

namespace Application.Users
{
    public interface IUserFoodPreferencesService
    {
        Task AddUserFoodPreferencesAsync(UserFoodPreferences userFoodPreferences);

        Task<IEnumerable<UserFoodPreferences?>> GetAllRestrictionsAsync(string userEmail);

        Task deleteAllRestrictionsPreferences(string userEmail);
    }
}

