/*
 Test: Add Integration Test to ConfirmationCodeRepository 
 Collaborators: Mariana Murillo
 */

using System;
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
using Microsoft.Data.SqlClient;

namespace IntegrationTests.Infrastructure.Users.Repositories
{
    public class ConfirmationCodeRepositoryTests
    {
        [Fact]
        public async Task SaveCodeAsyncWithValidCodeShouldBeSuccessful()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IConfirmationCodeRepository>();

            var code = new ConfirmationCode("gerardo.murillo07@gmail.com", 123456);


            // Act
            await repository.SaveCodeAsync(code);

            // Assert
            var codeToTest = await repository.GetCodeByEmail(code.Email);
            codeToTest.Email.Should().Be(code.Email);
        }

        [Fact]
        public async Task SaveCodeAsyncWithInvalidCodeShouldFail()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IConfirmationCodeRepository>();

            //email does not exist in db
            var code = new ConfirmationCode("test@email.com", 123456);

            // Act
            var exceptionDetails = Assert.ThrowsAsync<SqlException>(() => repository.SaveCodeAsync(code));

            // Assert
            Assert.Contains("The INSERT statement conflicted with the FOREIGN KEY constraint ", exceptionDetails.Result.Message);
        }


        [Fact]
        public async Task GetCodeByEmailWithInvalidEmailShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IConfirmationCodeRepository>();

            // Act
            var codeToTest = await repository.GetCodeByEmail("corredeprueba@hotmail.com");

            // Assert

            codeToTest.Should().BeNull();
        }

        [Fact]
        public async Task GetCodeByEmailWithValidEmailShouldReturnValidInstance()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IConfirmationCodeRepository>();
            var code = new ConfirmationCode("gerardo.murillo07@gmail.com", 123456);
            await repository.SaveCodeAsync(code);
            // Act
            var codeToTest = await repository.GetCodeByEmail(code.Email);

            // Assert

            codeToTest.Email.Should().BeEquivalentTo(code.Email);
        }

        [Fact]
        public async Task DeleteCodeForEmailWithValidEmailShouldBeSuccessful()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IConfirmationCodeRepository>();

            var code = new ConfirmationCode("gerardo.murillo07@gmail.com", 654321);
            await repository.SaveCodeAsync(code);

            // Act
            await repository.DeleteCodeForEmail("kimbyCR@gmail.com");
            var codeToTest = await repository.GetCodeByEmail("kimbyCR@gmail.com");

            // Assert

            codeToTest.Should().BeNull();
        }

    }
}
