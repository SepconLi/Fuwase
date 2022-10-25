using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Application.Donations.Implementations;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Donations.DTOs;
using Domain.Donations.Entities;
using Domain.Donations.Repositories;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Builder;
using Infrastructure.Orders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Users.Repositories;
using Infrastructure.Users.Repositories;
using Domain.Users.Entities;
using Infrastructure.Users;

namespace IntegrationTests.Infrastructure.Users.Repositories
{
    public class UserFoodPreferencesRepositoryTests
    {
        [Fact]
        public async void addUserFoodPreferencesIsNotNullTest()
        {
            var email = "fabian.gonzalezrojas@ucr.ac.cr";
            var allergen = "Sulfitos";

            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<UsersDbContext>(options=>options.UseSqlServer("TestConnection"));
            builder.Services.AddScoped <IUserFoodPreferencesRepository, UserFoodPreferencesRepository>();
            var app = builder.Build();
            var repository = app.Services.GetRequiredService<IUserFoodPreferencesRepository>();

            UserFoodPreferences newPreferences = new UserFoodPreferences(email, allergen);

            // Make sure there`s no preferences stored for this email
            await repository.deleteAllRestrictionsPreferences(email);
            await repository.SaveAsync(newPreferences);

            var result = await repository.GetAllRestrictionsAsync(email);
            result.Should().NotBeNull();
        }

        [Fact]
        public async void addUserFoodPreferencesCorrectAttributesTest()
        {
            var email = "fabian.gonzalezrojas@ucr.ac.cr";
            var allergen = "Sulfitos";

            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<UsersDbContext>(options => options.UseSqlServer("TestConnection"));
            builder.Services.AddScoped<IUserFoodPreferencesRepository, UserFoodPreferencesRepository>();
            var app = builder.Build();
            var repository = app.Services.GetRequiredService<IUserFoodPreferencesRepository>();

            UserFoodPreferences newPreferences = new UserFoodPreferences(email, allergen);

            // Make sure there`s no preferences stored for this email
            await repository.deleteAllRestrictionsPreferences(email);
            await repository.SaveAsync(newPreferences);

            var result = await repository.GetAllRestrictionsAsync(email);

            result.First()!.UserEmail.Should().Be(email);
            result.First()!.FoodRestriction.Should().Be(allergen);
        }

    }
}
