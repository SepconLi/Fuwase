using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Domain.Users.Entities;
using Domain.Core.ValueObjects;
using Domain.Core.Helpers;

namespace UnitTests.Domain.Users.Entities
{
    public class UserFoodPreferencesTests
    {
        [Fact]
        public void UserFoodPreferencesTestsEmptyUserEmail()
        {
            //Arrange
            var emptyPreferences = new UserFoodPreferences();
            // Act and assert
            emptyPreferences.UserEmail.Should().Be("");
        }

        [Fact]
        public void UserFoodPreferencesTestsEmptyFoodRestriction()
        {
            //Arrange
            var emptyPreferences = new UserFoodPreferences();
            // Act and assert
            emptyPreferences.FoodRestriction.Should().Be("");
        }

        [Fact]
        public void UserFoodPreferencesTestsUserEmail()
        {
            //Arrange
            var preferences = new UserFoodPreferences("fabian.gonzalezrojas@ucr.ac.cr","Sulfitos");
            // Act and assert
            preferences.UserEmail.Should().Be("fabian.gonzalezrojas@ucr.ac.cr");
        }

        [Fact]
        public void UserFoodPreferencesTestsFoodRestriction()
        {
            //Arrange
            var preferences = new UserFoodPreferences("fabian.gonzalezrojas@ucr.ac.cr", "Sulfitos");
            // Act and assert
            preferences.FoodRestriction.Should().Be("Sulfitos");
        }
    }
}
