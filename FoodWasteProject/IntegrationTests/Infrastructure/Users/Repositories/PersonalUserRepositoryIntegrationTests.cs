/*
 Test: Add Integration Test to PersonalUserRepository to test user registration funcionality. US: CD-US-1.5, CD-US-1.1. Subtask: CD-US-1.5.3.
Acceptance Criteria:
- Given that the user enters their email that already exists, they are made aware that the email is already registered.
- Given that the user enters all the data correctly in the form, the information is stored.
Participants: Emmanuel Zúñiga, Nathan Miranda
 */
using Domain.Users.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Domain.Users.Entities;
using Microsoft.AspNetCore.Builder;
using Infrastructure;
using Application;
using Microsoft.Extensions.Configuration;
using System;

namespace IntegrationTests.Infrastructure.Users.Repositories
{
    public class PersonalUserRepositoryIntegrationTests {

        //safe user in data base
        [Fact]
        public async Task PersonalUserRepositorySaveAsyncWithValidUserShouldSaveUserInDB()
        {
            // Arrenge
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            

            var _person = new PersonalUser("123456789", "Usuario", "Rodriguez", "userrodriguez@gmail.com", "UserRodi", 88888888, "Patito.20"
                , 1, "aqswdefrgthy", true, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            await repository.SaveAsync(_person);

            // Act
            var _personToTest = await repository.GetPersonalUserByEmail("userrodriguez@gmail.com");

            // Assert
            _personToTest.Should().Be(_person);
        }
        //should return null if user is incorrect
        [Fact]
        public async Task PersonalUserRepositorySaveAsyncWithValidUserShouldSaveAndInvalidInDB()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            var _person = new PersonalUser("123456789", "Usuario", "Juarez", "userJuarez@gmail.com", "UserJuar", 88888888, "Patito.20"
                , 1, "aqswdefrgthy", true, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            await repository.SaveAsync(_person);

            // Arrange
            var _personToTest = await repository.GetPersonalUserByEmail("useruarez@gmail.com");

            // Assert
            _personToTest.Should().BeNull();
        }

        [Fact]
        public async Task PersonalUserRepositorySaveAsyncWithInvalidUserShouldNotSaveUserInDB()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            var _person = new PersonalUser("123456789", "Usuario_1", "Juarez", null, "UserJuar", 88888888, "Patito.20"
               , 1, "aqswdefrgthy", true, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");


            // Arrange
            var exceptionDetails = Assert.ThrowsAsync<InvalidOperationException>(() => repository.SaveAsync(_person));

            // Assert
            Assert.Equal("Unable to track an entity of type 'PersonalUser' because its primary key property 'Email' is null.", exceptionDetails.Result.Message);
        }

        //get a valid user from db by email
        [Fact]
        public async Task GetPersonalUserByEmailValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            //Act
            var _person = await repository.GetPersonalUserByEmail("userJuarez@gmail.com");
            // Assert
            _person.Email.Should().Be("userJuarez@gmail.com");
        }

        [Fact]
        public async Task GetPersonalUserByEmailShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            //Act
            var _personToTest = await repository.GetPersonalUserByEmail("notInDB@gmail.com");
            // Assert
            _personToTest.Should().BeNull();
        }

        //Get USER BY id valid
        [Fact]
        public async Task GetPersonalUserByIdNumberValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            //Act
            var _personalToTest = await repository.GetPersonalUserByIdNumber("123456789");
            // Assert
            _personalToTest.IdNumber.Should().Be("123456789");
        }

        [Fact]
        public async Task GetPersonalUserByIdNumShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            //Act
            var _personalUserToTest = await repository.GetPersonalUserByIdNumber("0000000000");
            // Assert
            _personalUserToTest.Should().BeNull();
        }

        [Fact]
        public async Task GetPersonalUserByUsernameValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            //Act
            var _personalToTest = await repository.GetPersonalUserByUserName("UserJuar");
            // Assert
            _personalToTest.UserName.Should().Be("UserJuar");
        }

        [Fact]
        public async Task GetPersonalUserByUsernameShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            //Act
            var _businessToTest = await repository.GetUserByUserName("NOtINDB");
            // Assert
            _businessToTest.Should().BeNull();
        }
    }
}
