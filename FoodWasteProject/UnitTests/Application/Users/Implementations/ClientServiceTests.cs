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
	public class ClientServiceTests
	{
        private static IList<Client> GetClients()
        {
            IList<Client> clients = new List<Client>();
            var client01 = new Client("masXMenos@gmail.com", "masXMenos.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 0, "../images/Default_User.png");
            var client02 = new Client("kimbyCR@gmail.com", "kimby.cr", 25697845, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "Heredia", "Heredia", "Heredia", 0, "../images/Default_User.png");
            var client03 = new Client("lizano@gmail.com", "lizano.cr", 24563265, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "Alajuela", "Alajuela", "Alajuela", 0, "../images/Default_User.png");
            var client04 = new Client("suli@gmail.com", "suli_cr", 25784510, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            clients.Add(client01);
            clients.Add(client02);
            clients.Add(client03);
            clients.Add(client04);

            return clients;
        }

        [Fact]
        public async void GetClientsByEmailInvalid()
        {
            // arrange
            var email = "testEmail@gmail.com";
            var user = new Client();
            var mockClientRepository = new Mock<IClientRepository>();
            mockClientRepository.Setup(repo => repo.GetClientByEmail(email)).ReturnsAsync(user);
            var clientService = new ClientService(mockClientRepository.Object);

            // act
            var result = await clientService.GetClientByEmail(email);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void GetBusinessUserByEmailValid()
        {
            // arrange
            var user = GetClients()[0];
            var mockClientRepository = new Mock<IClientRepository>();
            mockClientRepository.Setup(repo => repo.GetClientByEmail(user.Email)).ReturnsAsync(user);
            var clientService = new ClientService(mockClientRepository.Object);

            // act
            var result = await clientService.GetClientByEmail(user.Email);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void GetClientsByUserNameInvalid()
        {
            // arrange
            var userName = "testUserName";
            var user = new Client();
            var mockClientRepository = new Mock<IClientRepository>();
            mockClientRepository.Setup(repo => repo.GetClientByUserName(userName)).ReturnsAsync(user);
            var clientService = new ClientService(mockClientRepository.Object);

            // act
            var result = await clientService.GetClientByUserName(userName);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void GetBusinessUserByUserNameValid()
        {
            // arrange
            var user = GetClients()[0];
            var mockClientRepository = new Mock<IClientRepository>();
            mockClientRepository.Setup(repo => repo.GetClientByUserName(user.UserName)).ReturnsAsync(user);
            var clientService = new ClientService(mockClientRepository.Object);

            // act
            var result = await clientService.GetClientByUserName(user.UserName);

            //assert
            result.Should().Be(user);
        }

        [Fact]
        public async void AddClientAsyncWithValidUserShouldAddUser()
        {
            // arrange
            var client01 = new Client("masXMenos@gmail.com", "masXMenos.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 0, "../images/Default_User.png");

            var mockClientRepository = new Mock<IClientRepository>();

            var clientRepository = new ClientService(mockClientRepository.Object);

            // act
            await clientRepository.AddClientAsync(client01);
            // assert
            mockClientRepository.Verify(repo => repo.SaveAsync(client01), Times.Once);

        }
    }
}
