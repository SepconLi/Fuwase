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
	public class ClientRepositoryTests
	{
        [Fact]
        public async Task ClientRepositorySaveAsyncWithValidUserShouldSaveUserInDB()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IClientRepository>();

            var _client = new Client("lizano@gmail.com", "lizano.cr", 24563265, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "Alajuela", "Alajuela", "Alajuela", 0, "../images/Default_User.png");

            await repository.SaveAsync(_client);

            // Arrange
            var _clientToTest = await repository.GetClientByEmail("lizano@gmail.com");

            // Assert
            _clientToTest.Should().Be(_client);
        }

        [Fact]
        public async Task ClientRepositorySaveAsyncWithInvalidUserShouldNotSaveUserInDB()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IClientRepository>();

            var _client = new Client(null, "lizano.cr", 24563265, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "Alajuela", "Alajuela", "Alajuela", 0, "../images/Default_User.png");

            // Arrange
            var exceptionDetails = Assert.ThrowsAsync<InvalidOperationException>(() => repository.SaveAsync(_client));

            // Assert
            Assert.Equal("Unable to track an entity of type 'Client' because its primary key property 'Email' is null.", exceptionDetails.Result.Message);
        }

        [Fact]
        public async Task GetClientByEmailValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IClientRepository>();

            var _client = new Client("kimbyCR@gmail.com", "kimby.cr", 25697845, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
            false, "Business", "Heredia", "Heredia", "Heredia", 0, "../images/Default_User.png");
            await repository.SaveAsync(_client);

            //Act
            var _clientToTest = await repository.GetClientByEmail("kimbyCR@gmail.com");
            // Assert
            _clientToTest.Email.Should().Be("kimbyCR@gmail.com");
        }

        [Fact]
        public async Task GetClientByEmailShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IClientRepository>();

            //Act
            var _clientToTest = await repository.GetClientByEmail("testClient@gmail.com");
            // Assert
            _clientToTest.Should().BeNull();
        }

        [Fact]
        public async Task GetClientByUsernameValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IClientRepository>();

            var _client = new Client("suliCR@gmail.com", "Suli_CostaRica", 21659878, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
            false, "Business", "Alajuela", "Alajuela", "Alajuela", 0, "../images/Default_User.png");
            await repository.SaveAsync(_client);

            //Act
            var _clientToTest = await repository.GetClientByUserName("Suli_CostaRica");
            // Assert
            _clientToTest.UserName.Should().Be("Suli_CostaRica");
        }

        [Fact]
        public async Task GetClientByUsernameShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IClientRepository>();

            //Act
            var _clientToTest = await repository.GetClientByUserName("testClient");
            // Assert
            _clientToTest.Should().BeNull();
        }
    }
}
