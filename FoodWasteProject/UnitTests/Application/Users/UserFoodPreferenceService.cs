using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Users;
using Application.Users.Implementations;
using Domain.Users.Entities;
using Moq;
using Domain.Users.Repositories;
using FluentAssertions;

namespace UnitTests.Application.Users
{
    public class UserFoodPreferenceService
    {
        [Fact]
        public async Task deleteWriteReadFoodPreferencesByEmailTest()
        {
            //arrange
            var mockEmail = "fabian.gonzalezrojas@ucr.ac.cr";
            var mockPreference = "Sulfitos";
            var userFoodPreferences = new UserFoodPreferences();
            var Preferences = new UserFoodPreferences(mockEmail, mockPreference);
            IList<UserFoodPreferences> userFoodPreference = new List<UserFoodPreferences>();

            userFoodPreference.Add(Preferences);
            var mockUserFoodPreferencesRepository = new Mock<IUserFoodPreferencesRepository>();
            var userFoodPreferencesService = new UserFoodPreferencesService(mockUserFoodPreferencesRepository.Object);
            mockUserFoodPreferencesRepository.Setup(repo => repo.GetAllRestrictionsAsync(mockEmail)).ReturnsAsync(userFoodPreference);

            //act
            await userFoodPreferencesService.deleteAllRestrictionsPreferences(mockEmail);
            await userFoodPreferencesService.AddUserFoodPreferencesAsync(userFoodPreferences);
            var result = await userFoodPreferencesService.GetAllRestrictionsAsync(mockEmail);

            //assert
            result.First()!.UserEmail.Should().Be(mockEmail);
            result.First()!.FoodRestriction.Should().Be(mockPreference);
        }
    }
}
