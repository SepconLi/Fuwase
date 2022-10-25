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
    public class BusinessUserRepositoryTests
    {
        // Pair Programming
        // Driver: Mariana Murillo
        // Navigator: Álvaro Miranda
        // CD-US-1.6(PIIB22102-264)
        [Fact]
        public async Task BusinessUserRepositorySaveAsyncWithValidUserShouldSaveUserInDB()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IBusinessUserRepository>();

            var _business = new BusinessUser("Soda Las Mariposas", "4567891235", DateTime.Today, "Álvaro Miranda", "San Antonio", "Alajuela",
                "Alajuela", 0, "sodalasmariposas@gmail.com", "SodaLasMariposas", "password123456", 1, "ldksjfoiweewla", false, "Business", 54698745, "../images/Default_User.png");

            await repository.SaveAsync(_business);

            // Arrange
            var _businessToTest = await repository.GetBusinessUserByEmail("sodalasmariposas@gmail.com");

            // Assert
            _businessToTest.Should().Be(_business);
        }

        // Pair Programming
        // Driver: Álvaro Miranda
        // Navigator: Mariana Murillo
        // CD-US-1.6(PIIB22102-264)

        [Fact]
        public async Task BusinessUserRepositorySaveAsyncWithInvalidUserShouldNotSaveUserInDB()
        {
            // Act

            var builder = WebApplication.CreateBuilder();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IBusinessUserRepository>();

            var _business = new BusinessUser("Soda Las Mariposas", "4567891235", DateTime.Today, "Álvaro Miranda", "San Antonio", "Alajuela",
                "Alajuela", 0, null, "SodaLasMariposas", "password123456", 1, "ldksjfoiweewla", false, "Business", 54698745, "../images/Default_User.png");

            // Arrange
            var exceptionDetails = Assert.ThrowsAsync<InvalidOperationException>(() => repository.SaveAsync(_business));

            // Assert
            Assert.Equal("Unable to track an entity of type 'BusinessUser' because its primary key property 'Email' is null.", exceptionDetails.Result.Message);
        }

        [Fact]
        public async Task GetBusinessUserByEmailValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IBusinessUserRepository>();

            //Act
            var _businessToTest = await repository.GetBusinessUserByEmail("sodalasmariposas@gmail.com");
            // Assert
            _businessToTest.Email.Should().Be("sodalasmariposas@gmail.com");
        }

        [Fact]
        public async Task GetBusinessUserByEmailShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IBusinessUserRepository>();

            //Act
            var _businessToTest = await repository.GetBusinessUserByEmail("sodalossapitos@gmail.com");
            // Assert
            _businessToTest.Should().BeNull();
        }

        [Fact]
        public async Task GetBusinessUserByLegalDocumentValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IBusinessUserRepository>();

            //Act
            var _businessToTest = await repository.GetBusinessUserByLegalDocument("4567891235");
            // Assert
            _businessToTest.Legal_Document.Should().Be("4567891235");
        }

        [Fact]
        public async Task GetBusinessUserByLegalDocumentShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IBusinessUserRepository>();

            //Act
            var _businessToTest = await repository.GetBusinessUserByLegalDocument("7894561238");
            // Assert
            _businessToTest.Should().BeNull();
        }

        [Fact]
        public async Task GetBusinessUserByUsernameValid()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IBusinessUserRepository>();

            //Act
            var _businessToTest = await repository.GetBusinessUserByUserName("SodaLasMariposas");
            // Assert
            _businessToTest.UserName.Should().Be("SodaLasMariposas");
        }

        [Fact]
        public async Task GetBusinessUserByUsernameShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IBusinessUserRepository>();

            //Act
            var _businessToTest = await repository.GetBusinessUserByUserName("SodaLosSapitos");
            // Assert
            _businessToTest.Should().BeNull();
        }
    }
}
