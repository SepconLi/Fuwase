/*
 Test: Add Unit Test to RedirectInformationService. 
Collaborators: Mariana Murillo Q.
 */
using System.Collections.Generic;
//Project imports
using Domain.Utilities.Entities;
using Domain.Utilities.Repositories;
using Application.Utilities.Implementations;
//Nugets imports
using Xunit;
using FluentAssertions;
using Moq;


namespace UnitTests.Application.Utilities.Implementations
{
    public class RedirectInformationServiceTests
    {
        [Fact]
        public async void AddRedirectInformationAsyncWithValidInfoShouldBeSuccessful()
        {
            // arrange
            var info = new RedirectInformation("/route", "test@email.com", "param");


            var mockRedirectInfoRepository = new Mock<IRedirectInformationRepository>();

            var redirectInfoService = new RedirectInformationService(mockRedirectInfoRepository.Object);

            // act
            await redirectInfoService.AddRedirectInformationAsync(info);

            // assert
            mockRedirectInfoRepository.Verify(repo => repo.SaveAsync(info), Times.Once);

        }

        [Fact]
        public async void GetRedirectInfoWithValidEmailShouldReturnValidInstance()
        {
            // Arrange
            var info = new RedirectInformation("/route", "test@email.com", "param");

            var mockRedirectInfoRepository = new Mock<IRedirectInformationRepository>();
            mockRedirectInfoRepository.Setup(repo => repo.GetRedirectInformationByEmail(info.Email)).ReturnsAsync(info);
            var redirectInfoService = new RedirectInformationService(mockRedirectInfoRepository.Object);

            await redirectInfoService.AddRedirectInformationAsync(info);

            // Act
            var infoTest = await redirectInfoService.GetRedirectInformationByEmail(info.Email);

            //Assert
            infoTest.Should().BeEquivalentTo(info);

        }

        [Fact]
        public async void GetRedirectInfoWithInValidEmailShouldReturnNullInstance()
        {
            // Arrange
            var info = new RedirectInformation("/route", "test@email.com", "param");

            var mockRedirectInfoRepository = new Mock<IRedirectInformationRepository>();
            mockRedirectInfoRepository.Setup(repo => repo.GetRedirectInformationByEmail(info.Email)).ReturnsAsync(info);
            var redirectInfoService = new RedirectInformationService(mockRedirectInfoRepository.Object);

            await redirectInfoService.AddRedirectInformationAsync(info);

            var invalidEmail = "correo@email.com";

            // Act
            var infoTest = await redirectInfoService.GetRedirectInformationByEmail(invalidEmail);

            //Assert
            infoTest.Should().BeNull();

        }

        [Fact]
        public async void GetRedirectInfoWithValidHashShouldReturnValidInstance()
        {
            // Arrange
            var info = new RedirectInformation("/route", "test@email.com", "param");

            var mockRedirectInfoRepository = new Mock<IRedirectInformationRepository>();
            mockRedirectInfoRepository.Setup(repo => repo.GetRedirectInformationByHash(info.Hash)).ReturnsAsync(info);
            var redirectInfoService = new RedirectInformationService(mockRedirectInfoRepository.Object);

            await redirectInfoService.AddRedirectInformationAsync(info);

            // Act
            var infoTest = await redirectInfoService.GetRedirectInformationByHash(info.Hash);

            //Assert
            infoTest.Should().BeEquivalentTo(info);

        }

        [Fact]
        public async void GetRedirectInfoWithInValidHashShouldReturnNullInstance()
        {
            // Arrange
            var info = new RedirectInformation("/route", "test@email.com", "param");

            var mockRedirectInfoRepository = new Mock<IRedirectInformationRepository>();
            mockRedirectInfoRepository.Setup(repo => repo.GetRedirectInformationByHash(info.Hash)).ReturnsAsync(info);
            var redirectInfoService = new RedirectInformationService(mockRedirectInfoRepository.Object);

            await redirectInfoService.AddRedirectInformationAsync(info);

            var invalidHash = "123456789";

            // Act
            var infoTest = await redirectInfoService.GetRedirectInformationByHash(invalidHash);

            //Assert
            infoTest.Should().BeNull();

        }

        [Fact]
        public async void DeleteRedirectInfoShouldBeSuccessful()
        {
            // Arrange
            var info = new RedirectInformation("/route", "test@email.com", "param");

            var mockRedirectInfoRepository = new Mock<IRedirectInformationRepository>();
            var redirectInfoService = new RedirectInformationService(mockRedirectInfoRepository.Object);

            await redirectInfoService.AddRedirectInformationAsync(info);

            // Act
            await redirectInfoService.DeleteRedirectInformation(info);

            //Assert
            var infoTest = await redirectInfoService.GetRedirectInformationByEmail(info.Email);
            infoTest.Should().BeNull();

        }
    }
}
