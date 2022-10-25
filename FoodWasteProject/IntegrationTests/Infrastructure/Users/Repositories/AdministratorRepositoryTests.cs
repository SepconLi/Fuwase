/*
 Test: Add Integration Test to AdministratorRepository to test Administrator authorization funcionality. US: CD-US-6.9. Subtask: CD-US-6.9.1.
Acceptance Criteria:
- When logging in as an administrator, the pages not needed by the administrator such as a list of donations of the account, will not be shown
Collaborators: Emmanuel Zúñiga, Nathan Miranda, Mariana Murillo, Álvaro Miranda
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


namespace IntegrationTests.Infrastructure.Users.Repositories
{
    public class AdministratorRepositoryTests
    {
        [Fact]
        public async Task AdministratorRepositorySaveAsyncWithInvalidUserShouldNotSaveUserInDB()
        {

            // Arrange

            var builder = WebApplication.CreateBuilder();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();


            var repository = app.Services.GetRequiredService<IAdministratorRepository>();

            var admin = new Administrator(null, "pruebaAdmin", 88888888, "Patito.20", 1, "hashedemailPrueba@correo.com",
                true, "Admin", "admin1234", "Administrador", "Espinoza", "../images/Default_User.png");


            // Act
            var exceptionDetails = Assert.ThrowsAsync<InvalidOperationException>(() => repository.SaveAsync(admin));


            // Assert
            Assert.Equal("Unable to track an entity of type 'Administrator' because its primary key property 'Email' is null.", exceptionDetails.Result.Message);

        }



        [Fact]
        public async Task AdministratorRepositorySaveAsyncShouldSaveAdminInDB()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IAdministratorRepository>();

            var admin = new Administrator("administrator@gmail.com", "admin1234", 88888888, "Patito.20", 1, "hashedemail@correo.com",
                true, "Admin", "admin1234", "Administrador", "Rodriguez", "../images/Default_User.png");

            await repository.SaveAsync(admin);

            // Act
            var adminToTest = await repository.GetAdminByEmail(admin.Email);

            // Assert

            adminToTest.Should().BeEquivalentTo(admin);
        }

        [Fact]
        public async Task AdministratorRepositoryGetAdminByEmailWithInvalidEmailShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IAdministratorRepository>();

            // Act
            var adminToTest = await repository.GetAdminByEmail("corredeprueba@hotmail.com");

            // Assert

            adminToTest.Should().BeNull();
        }

        [Fact]
        public async Task AdministratorRepositoryGetAdministratorByUserNamelWithInvalidUserNameShouldReturnNull()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IAdministratorRepository>();

            var admin = new Administrator("administrator@gmail.com", "admin1234", 88888888, "Patito.20", 1, "hashedemail@correo.com",
                true, "Admin", "admin1234", "Administrador", "Rodriguez", "../images/Default_User.png");


            // Act
            var adminToTest = await repository.GetAdminByUserName("xXAdminstradorTestXx");

            // Assert

            adminToTest.Should().BeNull();
        }

        [Fact]
        public async Task AdministratorRepositoryGetAdministratorByUserNamelWithvalidUserNameShouldReturnValidInstance()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IAdministratorRepository>();

            var admin = new Administrator("administrator123456@gmail.com", "AdministratorTesting", 88888888, "Patito.20", 1, "hashedemail1234@correo.com",
                true, "Admin", "admin123456", "Administrador", "Matarrita", "../images/Default_User.png");

            //Save admin in the DB to test
            await repository.SaveAsync(admin);

            // Act
            var adminToTest = await repository.GetAdminByUserName("AdministratorTesting");

            // Assert

            adminToTest.Should().BeEquivalentTo(admin);
        }

        [Fact]
        public async Task AdministratorRepositoryGetEmailShouldReturnValidInstance()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IAdministratorRepository>();

            var admin = new Administrator("AdministradorPerez@gmail.com", "Perez", 88888888, "Patito.20", 1, "hashedemailPerez@correo.com",
                true, "Admin", "admin1234", "Administrador", "Perez", "../images/Default_User.png");

            //Save admin in the DB to test
            await repository.SaveAsync(admin);

            // Act 
            var adminToTest = await repository.GetAdminByEmail("AdministradorPerez@gmail.com");

            // Assert
            adminToTest.Email.Should().Be("AdministradorPerez@gmail.com");
        }

        [Fact]
        public async Task AdministratorRepositoryGetEmailShouldReturnNullInstance()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IAdministratorRepository>();

            // Act 
            var adminToTest = await repository.GetAdminByEmail("prueba1234567@gmail.com");

            // Assert
            adminToTest.Should().BeNull();
        }
    }
}
