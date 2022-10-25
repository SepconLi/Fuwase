/*
 Test: Add Unit Test to AdministratorService to test Administrator authorization funcionality. US: CD-US-6.9. Subtask: CD-US-6.9.1.
Acceptance Criteria:
- When logging in as an administrator, the pages not needed by the administrator such as a list of donations of the account, will not be shown
Collaborators: Emmanuel Zúñiga, Nathan Miranda, Mariana Murillo, Álvaro Miranda
 */
using System.Collections.Generic;
//Project imports
using Domain.Users.Entities;
using Domain.Users.Repositories;
using Application.Users.Implementations;
//Nugets imports
using Xunit;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.Users.Implementations
{
    public class AdministratorServiceTests
    {
        [Fact]
        public async void AddAdministratorAsyncWithValidAdminShouldAddAdmin()
        {
            // arrange
            var admin = new Administrator("administrator@gmail.com", "admin1234", 88888888, "Patito.20", 1, "hashedemail@correo.com",
                true, "Admin", "admin1234", "Administrador", "Rodriguez", "../images/Default_User.png");
            

            var mockAdminRepository = new Mock<IAdministratorRepository>();

            var adminService = new AdministratorService(mockAdminRepository.Object);

            // act
            await adminService.AddAdministratorAsync(admin);
 
            // assert
            mockAdminRepository.Verify(repo => repo.SaveAsync(admin), Times.Once);

        }

        [Fact]
        public async void GetAdministratorWithValidEmailShouldReturnValidInstance()
        {
            // Arrange
            var admin = new Administrator("administrator@gmail.com", "admin1234", 88888888, "Patito.20", 1, "hashedemail@correo.com",
                true, "Admin", "admin1234", "Administrador", "Rodriguez", "../images/Default_User.png");

            var mockAdminRepository = new Mock<IAdministratorRepository>();
            mockAdminRepository.Setup(repo => repo.GetAdminByEmail(admin.Email)).ReturnsAsync(admin);
            var adminService = new AdministratorService(mockAdminRepository.Object);

            await adminService.AddAdministratorAsync(admin);

            // Act
            var adminTest = await adminService.GetAdministratorByEmail(admin.Email);

            //Assert
            adminTest.Should().BeEquivalentTo(admin);

        }

        [Fact]
        public async void GetAdministratorWithInValidEmailShouldReturnNullIstance()
        {
            // Arrange
            var admin = new Administrator("administrator@gmail.com", "admin1234", 88888888, "Patito.20", 1, "hashedemail@correo.com",
                true, "Admin", "admin1234", "Administrador", "Rodriguez", "../images/Default_User.png");

            var mockAdminRepository = new Mock<IAdministratorRepository>();
            mockAdminRepository.Setup(repo => repo.GetAdminByEmail(admin.Email)).ReturnsAsync(admin);
            var adminService = new AdministratorService(mockAdminRepository.Object);

            await adminService.AddAdministratorAsync(admin);

            var invalidEmail = "correo@email.com";

            // Act
            var adminTest = await adminService.GetAdministratorByEmail(invalidEmail);

            //Assert
            adminTest.Should().BeNull();

        }

        [Fact]
        public async void GetAdministratorWithValidUsenameShouldReturnValidIstance()
        {
            // Arrange
            var admin = new Administrator("administrator@gmail.com", "admin1234", 88888888, "Patito.20", 1, "hashedemail@correo.com",
                true, "Admin", "admin1234", "Administrador", "Rodriguez", "../images/Default_User.png");

            var mockAdminRepository = new Mock<IAdministratorRepository>();
            mockAdminRepository.Setup(repo => repo.GetAdminByUserName(admin.UserName)).ReturnsAsync(admin);
            var adminService = new AdministratorService(mockAdminRepository.Object);

            await adminService.AddAdministratorAsync(admin);


            // Act
            var adminTest = await adminService.GetAdministratorByUserName(admin.UserName);

            //Assert
            adminTest.Should().BeEquivalentTo(admin);

        }

        [Fact]
        public async void GetAdministratorWithInValidUsernameShouldReturnNullIstance()
        {
            // Arrange
            var admin = new Administrator("administrator@gmail.com", "admin1234", 88888888, "Patito.20", 1, "hashedemail@correo.com",
                true, "Admin", "admin1234", "Administrador", "Rodriguez", "../images/Default_User.png");

            var mockAdminRepository = new Mock<IAdministratorRepository>();
            mockAdminRepository.Setup(repo => repo.GetAdminByUserName(admin.UserName)).ReturnsAsync(admin);
            var adminService = new AdministratorService(mockAdminRepository.Object);

            await adminService.AddAdministratorAsync(admin);

            var invalidUsername = "administratorPerez";

            // Act
            var adminTest = await adminService.GetAdministratorByEmail(invalidUsername);

            //Assert
            adminTest.Should().BeNull();

        }

    }
}
