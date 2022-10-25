/*
 Test: Add Unit Test to ConfirmationCodeService.
 Developer: Mariana Murillo Q.
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
    public class ConfirmationCodeServiceTests
    {
        [Fact]
        public async void AddConfirmationCodeAsyncWithValidCodeShouldBeSuccessful()
        {
            // arrange
            var code = new ConfirmationCode("test@email.com",111111);


            var mockConfirmationCodeRepository = new Mock<IConfirmationCodeRepository>();

            var confirmationCodeService = new ConfirmationCodeService(mockConfirmationCodeRepository.Object);

            // act
            await confirmationCodeService.AddConfirmationCode(code);

            // assert
            mockConfirmationCodeRepository.Verify(repo => repo.SaveCodeAsync(code), Times.Once);

        }

        [Fact]
        public async void GetConfirmationCodeWithValidEmailShouldReturnValidInstance()
        {
            // Arrange
            var code = new ConfirmationCode("test@email.com", 111111);

            var mockConfirmationCodeRepository = new Mock<IConfirmationCodeRepository>();
            mockConfirmationCodeRepository.Setup(repo => repo.GetCodeByEmail(code.Email)).ReturnsAsync(code);
            var confirmationCodeService = new ConfirmationCodeService(mockConfirmationCodeRepository.Object);

            await confirmationCodeService.AddConfirmationCode(code);

            // Act
            var codeTest = await confirmationCodeService.GetCodeByEmail(code.Email);

            //Assert
            codeTest.Should().BeEquivalentTo(code);

        }

        [Fact]
        public async void GetConfirmationCodeWithInValidEmailShouldReturnNullInstance()
        {
            // Arrange
            var code = new ConfirmationCode("test@email.com", 111111);

            var mockConfirmationCodeRepository = new Mock<IConfirmationCodeRepository>();
            mockConfirmationCodeRepository.Setup(repo => repo.GetCodeByEmail(code.Email)).ReturnsAsync(code);
            var confirmationCodeService = new ConfirmationCodeService(mockConfirmationCodeRepository.Object);

            await confirmationCodeService.AddConfirmationCode(code);

            var invalidEmail = "correo@email.com";

            // Act
            var codeTest = await confirmationCodeService.GetCodeByEmail(invalidEmail);

            //Assert
            codeTest.Should().BeNull();

        }
        
        [Fact]
        public async void DeleteConfirmationCodeShouldBeSuccessful()
        {
            // Arrange
            var code = new ConfirmationCode("test@email.com", 111111);

            var mockConfirmationCodeRepository = new Mock<IConfirmationCodeRepository>();
            var confirmationCodeService = new ConfirmationCodeService(mockConfirmationCodeRepository.Object);

            await confirmationCodeService.AddConfirmationCode(code);

            // Act
            await confirmationCodeService.DeleteCodeForEmail(code.Email);

            //Assert
            var codeTest = await confirmationCodeService.GetCodeByEmail(code.Email);
            codeTest.Should().BeNull();

        }
    }
}
