/*
 Test: Add Integration Test to RedirectInformationRepository 
 Collaborators: Mariana Murillo
 */

using System;
using Domain.Utilities.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Domain.Utilities.Entities;
using Microsoft.AspNetCore.Builder;
using Infrastructure;
using Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace IntegrationTests.Infrastructure.Utilities.Repositories
{
    public class RedirectInformationRepositoryTests
    {
        [Fact]
        public async Task SaveAsyncWithValidInfoShouldBeSuccessful()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IRedirectInformationRepository>();

            var info = new RedirectInformation("/route", "gerardo.murillo07@gmail.com", "param");

            // Act
            await repository.SaveAsync(info);

            // Assert
            var infoToTest = await repository.GetRedirectInformationByHash(info.Hash);
            infoToTest.Should().BeEquivalentTo(info);
        }

        [Fact]
        public async Task SaveAsyncWithInvalidInfoShouldFail()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IRedirectInformationRepository>();

            //email does not exist in db
            var info = new RedirectInformation("/route","test@email.com", "param");

            // Act
            var exceptionDetails = Assert.ThrowsAsync<DbUpdateException>(() => repository.SaveAsync(info));

            // Assert
            Assert.Equal("An error occurred while saving the entity changes. See the inner exception for details.", exceptionDetails.Result.Message);
        }


        [Fact]
        public async Task GetRedirectInformationByEmailWithInvalidEmailShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IRedirectInformationRepository>();

            // Act
            var codeToTest = await repository.GetRedirectInformationByEmail("corredeprueba@hotmail.com");

            // Assert

            codeToTest.Should().BeNull();
        }

        [Fact]
        public async Task GetRedirectInformationByEmailWithValidEmailShouldReturnValidInstance()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IRedirectInformationRepository>();
            var info = new RedirectInformation("/route", "kimbyCR@gmail.com", "param");
            await repository.SaveAsync(info);
            // Act
            var infoToTest = await repository.GetRedirectInformationByEmail(info.Email);

            // Assert

            infoToTest.Email.Should().BeEquivalentTo(info.Email);
        }

        [Fact]
        public async Task GetRedirectInformationByHashWithInvalidHashShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IRedirectInformationRepository>();

            // Act
            var codeToTest = await repository.GetRedirectInformationByHash("hashDePruebaInvalido");

            // Assert

            codeToTest.Should().BeNull();
        }

        [Fact]
        public async Task GetRedirectInformationByHashWithValidHashShouldReturnValidInstance()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IRedirectInformationRepository>();
            var info = new RedirectInformation("/route", "kimbyCR@gmail.com", "param");
            await repository.SaveAsync(info);
            // Act
            var infoToTest = await repository.GetRedirectInformationByHash(info.Hash);

            // Assert

            infoToTest.Should().BeEquivalentTo(info);
        }

        [Fact]
        public async Task DeleteRedirectInformationWithValidEmailShouldBeSuccessful()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IRedirectInformationRepository>();

            var info = new RedirectInformation("/route", "kimbyCR@gmail.com", "param");
            await repository.SaveAsync(info);

            // Act
            await repository.DeleteRedirectInformation(info);
            var infoToTest = await repository.GetRedirectInformationByHash(info.Hash);

            // Assert

            infoToTest.Should().BeNull();
        }
    }
}
