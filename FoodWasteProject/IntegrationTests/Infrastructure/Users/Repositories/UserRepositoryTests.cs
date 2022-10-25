/*
 Test: Add Integration Test to PersonalUserRepository to test user registration funcionality. US: CD-US-1.5, CD-US-1.1. Subtask: CD-US-1.5.3.
Acceptance Criteria:
- Given that the user enters their email that already exists, they are made aware that the email is already registered.
- Given that the user enters all the data correctly in the form, the information is stored.
Participants: Emmanuel Zúñiga, Nathan Miranda
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Users.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Infrastructure.Users;
using Microsoft.Extensions.Logging;
using Domain.Users.Entities;
using Microsoft.AspNetCore.Builder;
using MudBlazor.Services;
using Infrastructure;
using Application;
using Microsoft.Extensions.Configuration;

namespace IntegrationTests.Infrastructure.Users.Repositories
{
	public class UserRepositoryTests
	{
        [Fact]
        public async Task UserRepositorySaveAsyncWithValidUserShouldSaveUserInDB()
        {
            // Arrenge
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IUserRepository>();


            var _person = new User("prueba@gmail.com", "UserEmanueloncio", 88888888, "Patito.20"
                , 1, "aqswdefrgthy", true, "Personal", "../images/Default_User.png");

            await repository.SaveAsync(_person);

            // Act
            var _personToTest = await repository.GetUserByEmail("prueba@gmail.com");

            // Assert
            _personToTest.Should().Be(_person);
        }

        [Fact]
        public async Task UserRepositorySaveAsyncWithValidUserShouldSaveAndInvalidInDB()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            var _person = new User("useredgardo@gmail.com", "UserEddie", 88888888, "Patito.20"
                , 1, "aqswdefrgthy", true, "Personal", "../images/Default_User.png");

            await repository.SaveAsync(_person);

            // Arrange
            var _personToTest = await repository.GetPersonalUserByEmail("userEdgardo@gmail.com");

            // Assert
            _personToTest.Should().BeNull();
        }

        [Fact]
        public void UserRepositorySaveAsyncWithInvalidUserShouldNotSaveUserInDB()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IUserRepository>();

            var _person = new User(null, "UserRodi", 88888888, "Patito.20"
                , 1, "aqswdefrgthy", true, "Personal", "../images/Default_User.png");


            // Arrange
            var exceptionDetails = Assert.ThrowsAsync<InvalidOperationException>(() => repository.SaveAsync(_person));

            // Assert
            Assert.Equal("Unable to track an entity of type 'User' because its primary key property 'Email' is null.", exceptionDetails.Result.Message);
        }

        [Fact]
        public async Task GetUserByEmailValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IUserRepository>();

            var _person = new User("userFederico@gmail.com", "UserFederico", 88888888, "Patito.20"
                , 1, "aqswdefrgthy", true, "Personal", "../images/Default_User.png");

            await repository.SaveAsync(_person);

            //Act
            var _userToTest = await repository.GetUserByEmail("userFederico@gmail.com");
            // Assert
            _userToTest.Email.Should().Be("userFederico@gmail.com");
        }

        [Fact]
        public async Task GetUserByEmailShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IUserRepository>();

            //Act
            var _userToTest = await repository.GetUserByEmail("userTest@gmail.com");
            // Assert
            _userToTest.Should().BeNull();
        }

        [Fact]
        public async Task GetUserByUserNameValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IUserRepository>();

            var _person = new User("userPedro@gmail.com", "UserPedro", 88888888, "Patito.20"
                    , 1, "aqswdefrgthy", true, "Personal", "../images/Default_User.png");
            await repository.SaveAsync(_person);

            //Act
            var _userToTest = await repository.GetUserByUserName("UserPedro");
            // Assert
            _userToTest.UserName.Should().Be("UserPedro");
        }

        [Fact]
        public async Task GetUserByUserNameShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IUserRepository>();

            //Act
            var _userToTest = await repository.GetUserByUserName("TestUserName");
            // Assert
            _userToTest.Should().BeNull();
        }

        [Fact]
        public async Task GetUserByHashedEmailValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IUserRepository>();

            var _person = new User("userFabiana@gmail.com", "UserFabiana", 88888888, "Patito.20"
                    , 1, "aiondfainsge", true, "Personal", "../images/Default_User.png");
            await repository.SaveAsync(_person);

            //Act
            var _userToTest = await repository.GetUserByHashedEmail("aiondfainsge");
            // Assert
            _userToTest.HashedEmail.Should().Be("aiondfainsge");
        }

        [Fact]
        public async Task GetUserByHashedEmailShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IUserRepository>();

            //Act
            var _userToTest = await repository.GetUserByHashedEmail("hashTest");
            // Assert
            _userToTest.Should().BeNull();
        }

        [Fact]
        public async Task UserRepositoryCheckUserCredentials()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            var _person = new User("userEmiliano@gmail.com", "UserEmiliano", 88888888, "Patito.20"
                , 1, "aqswdefrgthy", true, "Personal", "../images/Default_User.png");

            await repository.SaveAsync(_person);

            // Arrange
            var _userToTest = await repository.ValidateUserCredentials("userEmiliano@gmail.com", "Patito.20");

            // Assert
            _userToTest.Should().BeEquivalentTo(_person);
        }

        [Fact]
        public async Task UserRepositoryCheckUserCredentialsInvalid()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            var _person = new User("userKarla@gmail.com", "UserKarla", 88888888, "Patito.20"
                , 1, "aqswdefrgthy", true, "Personal", "../images/Default_User.png");

            await repository.SaveAsync(_person);

            // Arrange
            var _userToTest = await repository.ValidateUserCredentials("userKarla@gmail.com", "Patito.22");

            // Assert
            _userToTest.Should().BeNull();
        }
        
        [Fact]
        public async Task UserRepositoryUpdateUserValid()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IPersonalUserRepository>();

            var _person = new User("userFernandez@gmail.com", "UserRodi", 88888888, "Patito.20"
                , 1, "aqswdefrgthy", true, "Personal", "../images/Default_User.png");

            await repository.SaveAsync(_person);

            _person.Password = "Patito.22";

            // Arrange
            await repository.UpdateUser(_person);
            var _userToTest = await repository.GetUserByEmail("userFernandez@gmail.com");

            // Assert
            _userToTest.Should().BeEquivalentTo(_person);
        }
    }
}
