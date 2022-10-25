/*
 Test: Add Integration Test to PersonalUserService to test user registration funcionality. US: CD-US-1.5, CD-US-1.1. Subtask: CD-US-1.5.3.
Acceptance Criteria:
- Given that the user enters their email that already exists, they are made aware that the email is already registered.
- Given that the user enters all the data correctly in the form, the information is stored.
Participants: Emmanuel Zúñiga, Nathan Miranda
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
    public class PersonalUserServiceTest
    {

        private static IList<PersonalUser> GetPersonalUsers()
        {
            IList<PersonalUser> users = new List<PersonalUser>();
            var personalUser01 = new PersonalUser("111111111", "Nathan", "Natancio", "nathaniando@gmail.com",
                "xXNathanelioXx", 66666677, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            var personalUser02 = new PersonalUser("111111112", "Alvaro", "Alvarancio", "alv@gmail.com",
                "xXAlvaranteXx", 66666666, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            var personalUser03 = new PersonalUser("111111113", "Mariana", "Marianosa", "marianando@gmail.com",
                "xXMariananteXx", 66666688, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            var personalUser04 = new PersonalUser("111111114", "Emmanuel", "Annuel", "emmanuelio@gmail.com",
                "xXEmmanueliandoXx", 66666698, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");
            users.Add(personalUser01);
            users.Add(personalUser02);
            users.Add(personalUser03);
            users.Add(personalUser04);

            return users;
        }

        [Fact]
        public async void GetPersonalUserByEmailValid()
        {
            // arrange
            var user = GetPersonalUsers()[0];
            var mockPersonalUserRepository = new Mock<IPersonalUserRepository>();
            mockPersonalUserRepository.Setup(repo => repo.GetPersonalUserByEmail(user.Email)).ReturnsAsync(user);
            var personalUserService = new PersonalUserService(mockPersonalUserRepository.Object);

            // act
            var result = await personalUserService.GetPersonalUserByEmail(user.Email);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void GetPersonalUserByEmailInvalid()
        {
            // arrange
            var email = "testEmail@gmail.com";
            var user = new PersonalUser();
            var mockPersonalUserRepository = new Mock<IPersonalUserRepository>();
            mockPersonalUserRepository.Setup(repo => repo.GetPersonalUserByEmail(email)).ReturnsAsync(user);
            var personalUserService = new PersonalUserService(mockPersonalUserRepository.Object);

            // act
            var result = await personalUserService.GetPersonalUserByEmail(email);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void AddPersonalUserAsyncWithValidUserShouldAddUser()
        {
            // arrange
            var personalUser = new PersonalUser("111111119", "Jon", "Nieve", "jonnieve@gmail.com",
                "JonSnow", 88888888, "Patito.20", 1, "Loremipsumdolorsitamete", false, "Personal", "Cartago", "Cartago", "Cartago", 0, "../images/Default_User.png");

            var mockPersonalUserRepository = new Mock<IPersonalUserRepository>();

            var personalUserService = new PersonalUserService(mockPersonalUserRepository.Object);

            // act
            await personalUserService.AddPersonalUserAsync(personalUser);
            // assert
            mockPersonalUserRepository.Verify(repo => repo.SaveAsync(personalUser), Times.Once);

        }

        [Fact]
        public async void GetPersonalUserByUsernameValid()
        {
            // arrange
            var user = GetPersonalUsers()[3];
            var mockPersonalUserRepository = new Mock<IPersonalUserRepository>();
            mockPersonalUserRepository.Setup(repo => repo.GetPersonalUserByUserName(user.UserName)).ReturnsAsync(user);
            var personalUserService = new PersonalUserService(mockPersonalUserRepository.Object);

            // act
            var result = await personalUserService.GetPersonalUserByUserName(user.UserName);

            //assert
            result.Should().Be(user);
        }


        [Fact]
        public async void GetPersonalUserByUsernameInvalid()
        {
            // arrange
            var user = GetPersonalUsers()[3];
            var mockPersonalUserRepository = new Mock<IPersonalUserRepository>();
            mockPersonalUserRepository.Setup(repo => repo.GetPersonalUserByUserName(user.UserName)).ReturnsAsync(user);
            var personalUserService = new PersonalUserService(mockPersonalUserRepository.Object);

            // act
            var result = await personalUserService.GetPersonalUserByUserName("Nulluncio");

            //assert
            result.Should().BeNull();
        }
    }
}
