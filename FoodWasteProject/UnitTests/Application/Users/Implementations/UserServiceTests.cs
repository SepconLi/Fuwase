/*
 Test: Add Integration Test to UserService to test user registration funcionality. US: CD-US-1.5, CD-US-1.1. Subtask: CD-US-1.5.3.
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
using System;

namespace UnitTests.Application.Users.Implementations
{
    public class UserServiceTests
    {
        //Add user async
        [Fact]
        public async void AddUserAsyncWithValidUserShouldAddUser()
        {
            // arrange

            //To test the funcionality it is needed to create a personal user, because user is an abstract class
            var personalUser = new PersonalUser("111111119", "Jon", "Nieve", "jonnieve@gmail.com",
                "JonSnow", 88888888, "Patito.20", 1, "Loremipsumdolorsitamete", false, "Personal", "Cartago", "Cartago", "Cartago", 0, "../images/Default_User.png");

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.SaveAsync(personalUser));
            var userService = new UserService(mockUserRepository.Object);

            // act
            await userService.AddUserAsync(personalUser);
            // assert
            mockUserRepository.Verify(repo => repo.SaveAsync(personalUser), Times.Once);

        }


        [Fact]
        public async void GetUserByEmailValid()
        {
            var email = "jonnieve@gmail.com";
            var user = new PersonalUser();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetUserByEmail(email)).ReturnsAsync(user);
            var userService = new UserService(mockUserRepository.Object);

            var userFromEmail = await userService.GetUserByEmail(email);

            mockUserRepository.Verify(repo => repo.GetUserByEmail(email), Times.Once);
        }

        [Fact]
        public async void GetUserByEmailInValid()
        {
            var email = "NotInDb@gmail.com";
            var user = new PersonalUser();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetUserByEmail(email)).ReturnsAsync(user);
            var userService = new UserService(mockUserRepository.Object);

            var userFromEmail = await userService.GetUserByEmail(email);

            //assert
            userFromEmail.Should().Be(user);
        }



        [Fact]
        public async void GetUserByUserNameValid()
        {
            var userName = "JonSnow";
            var user = new PersonalUser();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetUserByUserName(userName)).ReturnsAsync(user);
            var userService = new UserService(mockUserRepository.Object);

            var userFromUserName = await userService.GetUserByUserName(userName);

            mockUserRepository.Verify(repo => repo.GetUserByUserName(userName), Times.Once);
        }

        [Fact]
        public async void GetUserByUserNameInvalid()
        {
            //arrenge
            var userName = "NotinDb";
            var user = new PersonalUser();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetUserByUserName(userName)).ReturnsAsync(user);
            var userService = new UserService(mockUserRepository.Object);
            //act
            var userFromUserName = await userService.GetUserByUserName(userName);
            //assert
            userFromUserName.Should().Be(user);
        }

        [Fact]
        public async void GetUserByHashedEmailValid()
        {
            //arrenge
            var hashedEmail = "Loremipsumdolorsitamete";
            var user = new PersonalUser();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetUserByUserName(hashedEmail)).ReturnsAsync(user);
            var userService = new UserService(mockUserRepository.Object);
            //act
            var userFromHashedEmail = await userService.GetUserByHashedEmail(hashedEmail);
            //assert
            mockUserRepository.Verify(repo => repo.GetUserByHashedEmail(hashedEmail), Times.Once);
        }

        [Fact]
        public async void GetUserByHashedEmailIvnalid()
        {

            var hashedEmail = "###############";
            var user = new PersonalUser();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetUserByUserName(hashedEmail)).ReturnsAsync(user);
            var userService = new UserService(mockUserRepository.Object);

            var userFromHashedEmail = await userService.GetUserByHashedEmail(hashedEmail);

            userFromHashedEmail.Should().BeNull();
        }

        [Fact]
        public async void UpdateUserValid()
        {
            var personalUser = new PersonalUser("111111119", "Jon", "Nieve", "jonnieve_2@gmail.com",
                "JonSnow_2", 88888888, "Patito.20", 1, "Loremipsumdolorsitamete", false, "Personal", "Cartago", "Cartago", "Cartago", 0, "../images/Default_User.png");

            var mockUserRepository = new Mock<IUserRepository>();

            var userService = new UserService(mockUserRepository.Object);
            //saves user
            mockUserRepository.Setup(repo => repo.SaveAsync(personalUser));
            await userService.AddUserAsync(personalUser);

            //updates users
            personalUser.Password = "Patito.22";
            mockUserRepository.Setup(repo => repo.UpdateUser(personalUser));

            await userService.UpdateUser(personalUser);

            mockUserRepository.Verify(repo => repo.UpdateUser(personalUser), Times.Once);
        }
    }
}
