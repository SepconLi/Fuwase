using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Project imports
using Domain.Users.Entities;
//Nugets imports
using Xunit;
using FluentAssertions;

namespace UnitTests.Domain.Users.Entities
{
	public class ClientUserTests
	{
        [Fact]
        public void ClientTestEmptyEmail()
        {
            //arange
            var client = new Client();
            //art and assert
            client.Email.Should().BeNullOrEmpty();
        }

        [Fact]
        public void ClientTestEmptyUserName()
        {
            //arange
            var client = new Client();
            //art and assert
            client.UserName.Should().BeNullOrEmpty();
        }
        [Fact]
        public void ClientTestEmptyPhoneNumber()
        {
            //arange
            var client = new Client();
            //art and assert
            client.PhoneNumber.Should().Be(0);
        }
        [Fact]
        public void ClientTestEmptyPassword()
        {
            //arange
            var client = new Client();
            //art and assert
            client.Password.Should().BeNullOrEmpty();
        }
        [Fact]
        public void ClientTestEmptyStatus()
        {
            //arange
            var client = new Client();
            //art and assert
            client.Status.Should().Be(0);
        }
        [Fact]
        public void ClientTestEmptyTown()
        {
            //arange
            var client = new Client();
            //art and assert
            client.Town.Should().BeNullOrEmpty();
        }
        [Fact]
        public void ClientTestEmptyDistrict()
        {
            //arange
            var client = new Client();
            //art and assert
            client.District.Should().BeNullOrEmpty();
        }
        [Fact]
        public void ClientTestEmptyProvince()
        {
            //arange
            var client = new Client();
            //art and assert
            client.Province.Should().BeNullOrEmpty();
        }
        [Fact]
        public void ClientTestEmptyStrikes()
        {
            //arange
            var client = new Client();
            //art and assert
            client.Strikes.Should().Be(0);
        }
        [Fact]
        public void ClientTestEmptyProfilePicture()
        {
            //arange
            var client = new Client();
            //art and assert
            client.Profile_Picture.Should().BeNullOrEmpty();
        }

        [Fact]
        public void ClientTestEmptyInstance()
        {
            //arange
            var client = new Client();
            var clientTest = new
            {
                Email = null as string,
                UserName = null as string,
                PhoneNumber = 0,
                Password = null as string,
                Status = 0,
                HashedEmail = "",
                Anom_Preference = false,
                Role = null as string,
                Town = null as string,
                District = null as string,
                Province = null as string,
                Strikes = 0,
                Profile_Picture = null as string
            };
            //art and assert
            client.Should().BeEquivalentTo(clientTest);
        }
        [Fact]
        public void ClientTestEmail()
        {
            //arange
            var client = new Client( "walmart@gmail.com", "walmart.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest", 
                        false, "Business", "San Vicente", "Moravia", "San José",  0, "../images/Default_User.png");
            //art and assert
            client.Email.Should().Be("walmart@gmail.com");
        }
        [Fact]
        public void ClientTestUserName()
        {
            //arange
            var client = new Client("walmart@gmail.com", "walmart.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 0, "../images/Default_User.png");
            //art and assert
            client.UserName.Should().Be("walmart.cr");
        }
        [Fact]
        public void ClientTestPhoneNumber()
        {
            //arange
            var client = new Client("walmart@gmail.com", "walmart.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 0, "../images/Default_User.png");
            //art and assert
            client.PhoneNumber.Should().Be(22563274);
        }
        [Fact]
        public void ClientTestPassword()
        {
            //arange
            var client = new Client("walmart@gmail.com", "walmart.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 0, "../images/Default_User.png");
            //art and assert
            client.Password.Should().Be("$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.");
        }
        [Fact]
        public void ClientTestStatus()
        {
            //arange
            var client = new Client("walmart@gmail.com", "walmart.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 0, "../images/Default_User.png");
            //art and assert
            client.Status.Should().Be(1);
        }
        [Fact]
        public void ClientTestTown()
        {
            //arange
            var client = new Client("walmart@gmail.com", "walmart.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 0, "../images/Default_User.png");
            //art and assert
            client.Town.Should().Be("San Vicente");
        }
        [Fact]
        public void ClientTestDistrict()
        {
            //arange
            var client = new Client("walmart@gmail.com", "walmart.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 0, "../images/Default_User.png");
            //art and assert
            client.District.Should().Be("Moravia");
        }
        [Fact]
        public void ClientTestProvince()
        {
            //arange
            var client = new Client("walmart@gmail.com", "walmart.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 0, "../images/Default_User.png");
            //art and assert
            client.Province.Should().Be("San José");
        }
        [Fact]
        public void ClientTestStrikes()
        {
            //arange
            var client = new Client("walmart@gmail.com", "walmart.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 1, "../images/Default_User.png");
            //art and assert
            client.Strikes.Should().Be(1);
        }
        [Fact]
        public void ClientTestInstance()
        {
            //arange
            var client = new Client("walmart@gmail.com", "walmart.cr", 22563274, "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "hashedEmailTest",
                        false, "Business", "San Vicente", "Moravia", "San José", 1, "../images/Default_User.png");
            var clientTest = new
            {
                Email = "walmart@gmail.com",
                UserName = "walmart.cr",
                PhoneNumber = 22563274,
                Password = "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",
                Status = 1,
                HashedEmail = "hashedEmailTest",
                Anom_Preference = false,
                Role = "Business",
                Town = "San Vicente",
                District = "Moravia",
                Province = "San José",
                Strikes = 1,
                Profile_Picture = "../images/Default_User.png"
            };
            //art and assert
            client.Should().BeEquivalentTo(clientTest);
        }
    }
}
