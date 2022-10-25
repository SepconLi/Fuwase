/* User's module - Imborrables
 * Collaboratos:
 * - Fabian Gonzalez
 * - Maeva Murcia
*-Summary: Implementation of User Repository Interface
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Repositories;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Users.Repositories
{
    internal class UserFoodPreferencesRepository : IUserFoodPreferencesRepository
    {
        protected readonly UsersDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public UserFoodPreferencesRepository(UsersDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task SaveAsync(UserFoodPreferences userFoodPreferences)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync($"EXEC insertNewUserPreference @userEmail={userFoodPreferences.UserEmail}, @foodRestriction={userFoodPreferences.FoodRestriction}");
        }
 
        public async Task<IEnumerable<UserFoodPreferences?>> GetAllRestrictionsAsync(string userEmail)
        {
            return await _dbContext.UserFoodPreferences.Where(u => u.UserEmail == userEmail)
                .Select(t => new UserFoodPreferences(t.UserEmail, t.FoodRestriction)).ToListAsync();
        }

        public async Task deleteAllRestrictionsPreferences(string userEmail)
        {
            await _dbContext.Database.ExecuteSqlRawAsync($"EXEC deleteAllRestrictionsPreferences @userEmail",
                new SqlParameter("userEmail", userEmail));
        }
    }
}