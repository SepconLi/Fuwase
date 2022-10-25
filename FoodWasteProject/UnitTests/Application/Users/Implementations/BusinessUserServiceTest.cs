/* User's module - Core Dummpers
 * Collaborators:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Testing for BusinessUserService
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class BusinessUserServiceTest
    {
        // Pair Programming
        // Driver: Mariana Murillo
        // Navigator: Álvaro Miranda
        // CD-US-1.6(PIIB22102-264)
        private static IList<BusinessUser> GetBusinessUsers()
        {
            IList<BusinessUser> users = new List<BusinessUser>();
            var businessUser01 = new BusinessUser("Soda Doña Julia", "1234567891", DateTime.Today, "Nathan Miranda", "San Vicente", "Moravia",
                "San José", 0, "sodadonajulia@gmail.com", "SodaDoñaJulia","password123456",1,"asldkjfalksd",false,"Business",85567945, "../images/Default_User.png");
            var businessUser02 = new BusinessUser("Soda Los Sapitos", "4567891235", DateTime.Today, "Álvaro Miranda", "San Antonio", "Alajuela",
                "Alajuela", 0, "sodalossapitos@gmail.com", "SodaLosSapitos", "password123456", 1, "qweruiozcxnvm", false, "Business", 85568545, "../images/Default_User.png");
            var businessUser03 = new BusinessUser("Automercado", "9638527415", DateTime.Today, "Emmanuel Zúñiga", "San Vicente", "Moravia",
                "San José", 0, "automercado@gmail.com", "Automercado", "password123456", 1, "asldkjfalksd", false, "Business", 22546857, "../images/Default_User.png");
            var businessUser04 = new BusinessUser("Walmart", "78945612", DateTime.Today, "Mariana Murillo", "San Vicente", "Moravia",
                "San José", 0, "walmart@gmail.com", "Walmart", "password123456", 1, "asldkjfalksd", false, "Business", 85571382, "../images/Default_User.png");

            users.Add(businessUser01);
            users.Add(businessUser02);
            users.Add(businessUser03);
            users.Add(businessUser04);

            return users;
        }

        // Pair Programming
        // Driver: Mariana Murillo
        // Navigator: Álvaro Miranda
        // CD-US-1.6(PIIB22102-264)
        [Fact]
        public async void GetBusinessUserByEmailInvalid()
        {
            // arrange
            var email = "testEmail@gmail.com";
            var user = new BusinessUser();
            var mockBusinessUserRepository = new Mock<IBusinessUserRepository>();
            mockBusinessUserRepository.Setup(repo => repo.GetBusinessUserByEmail(email)).ReturnsAsync(user);
            var businessUserService = new BusinessUserService(mockBusinessUserRepository.Object);

            // act
            var result = await businessUserService.GetBusinessUserByEmail(email);

            //assert
            result.Should().Be(user);
        }

        // Pair Programming
        // Driver: Álvaro Miranda
        // Navigator: Mariana Murillo
        // CD-US-1.6(PIIB22102-264)
        [Fact]
        public async void GetBusinessUserByEmailValid()
        {
            // arrange
            var user = GetBusinessUsers()[0];
            var mockBusinessUserRepository = new Mock<IBusinessUserRepository>();
            mockBusinessUserRepository.Setup(repo => repo.GetBusinessUserByEmail(user.Email)).ReturnsAsync(user);
            var businessUserService = new BusinessUserService(mockBusinessUserRepository.Object);

            // act
            var result = await businessUserService.GetBusinessUserByEmail(user.Email);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void GetBusinessUserByLegalDocumentInvalid()
        {
            // arrange
            var legalDocument = "123456";
            var user = new BusinessUser();
            var mockBusinessUserRepository = new Mock<IBusinessUserRepository>();
            mockBusinessUserRepository.Setup(repo => repo.GetBusinessUserByLegalDocument(legalDocument)).ReturnsAsync(user);
            var businessUserService = new BusinessUserService(mockBusinessUserRepository.Object);

            // act
            var result = await businessUserService.GetBusinessUserByLegalDocument(legalDocument);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void GetBusinessUserByLegalDocumentValid()
        {
            // arrange
            var user = GetBusinessUsers()[0];
            var mockBusinessUserRepository = new Mock<IBusinessUserRepository>();
            mockBusinessUserRepository.Setup(repo => repo.GetBusinessUserByLegalDocument(user.Legal_Document)).ReturnsAsync(user);
            var businessUserService = new BusinessUserService(mockBusinessUserRepository.Object);

            // act
            var result = await businessUserService.GetBusinessUserByLegalDocument(user.Legal_Document);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void GetBusinessUserByUsernameValid()
        {
            // arrange
            var user = GetBusinessUsers()[0];
            var mockBusinessUserRepository = new Mock<IBusinessUserRepository>();
            mockBusinessUserRepository.Setup(repo => repo.GetBusinessUserByEmail(user.UserName)).ReturnsAsync(user);
            var businessUserService = new BusinessUserService(mockBusinessUserRepository.Object);

            // act
            var result = await businessUserService.GetBusinessUserByEmail(user.UserName);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void GetBusinessUserByUserNameInvalid()
        {
            // arrange
            var username = "pepe";
            var user = new BusinessUser();
            var mockBusinessUserRepository = new Mock<IBusinessUserRepository>();
            mockBusinessUserRepository.Setup(repo => repo.GetBusinessUserByUserName(username)).ReturnsAsync(user);
            var businessUserService = new BusinessUserService(mockBusinessUserRepository.Object);

            // act
            var result = await businessUserService.GetBusinessUserByUserName(username);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void AddBusinessUserAsyncWithValidUserShouldAddUser()
        {
            // arrange
            var businessUser = new BusinessUser("Carnicería El Chorizo Feliz", "4568527193", DateTime.Today, "Emmanuel Zúñiga", "San Vicente", "Moravia",
                   "San José", 0, "elchorifeliz@gmail.com", "ElChorizoFeliz", "password123456", 1, "asldkjfalksd", false, "Business", 45685279, "../images/Default_User.png");

            var mockBusinessUserRepository = new Mock<IBusinessUserRepository>();

            var businessUserService = new BusinessUserService(mockBusinessUserRepository.Object);

            // act
            await businessUserService.AddBusinessUserAsync(businessUser);
            // assert
            mockBusinessUserRepository.Verify(repo => repo.SaveAsync(businessUser), Times.Once);

        }
    }
}
