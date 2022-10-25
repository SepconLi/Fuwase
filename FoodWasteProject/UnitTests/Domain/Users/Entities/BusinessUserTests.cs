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

namespace UnitTests.Users.Entities
{
    public class BusinessUserTests
    {
        [Fact]
        public void BusinessUserTestEmptyEmail() 
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.Email.Should().BeNullOrEmpty();
        }
        [Fact]
        public void BusinessUserTestEmptyUserName()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.UserName.Should().BeNullOrEmpty();
        }
        [Fact]
        public void BusinessUserTestEmptyPhoneNumber()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.PhoneNumber.Should().Be(0);
        }
        [Fact]
        public void BusinessUserTestEmptyPassword()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.Password.Should().BeNullOrEmpty();
        }
        [Fact]
        public void BusinessUserTestEmptyStatus()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.Status.Should().Be(0);
        }
        [Fact]
        public void BusinessUserTestEmptyTown()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.Town.Should().BeNullOrEmpty();
        }
        [Fact]
        public void BusinessUserTestEmptyDistrict()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.District.Should().BeNullOrEmpty();
        }
        [Fact]
        public void BusinessUserTestEmptyProvince()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.Province.Should().BeNullOrEmpty();
        }
        [Fact]
        public void BusinessUserTestEmptyStrikes()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.Strikes.Should().Be(0);
        }
        [Fact]
        public void BusinessUserTestEmptyBussinesUser_Name()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.Business_Name.Should().BeNullOrEmpty();
        }
        [Fact]
        public void BusinessUserTestEmptyLegal_Document()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.Legal_Document.Should().BeNullOrEmpty();
        }
        [Fact]
        public void BusinessUserTestEmptyAlliance_Start()
        {
            //arange
            var businessUser = new BusinessUser();
            var dateTest = new DateTime();
            //art and assert
            businessUser.Alliance_Start.Should().BeSameDateAs(dateTest);
        }
        [Fact]
        public void BusinessUserTestEmptyPerson_In_Charge()
        {
            //arange
            var businessUser = new BusinessUser();
            //art and assert
            businessUser.Person_In_Charge.Should().BeNullOrEmpty();
        }
        [Fact]
        public void BusinessUserTestEmptyInstance() 
        {
            //arange
            var businessUser = new BusinessUser();
            var businessUserTest = new {
                Business_Name = null as string,
                Legal_Document = null as string, 
                Alliance_Start = new DateTime(),
                Person_In_Charge = null as string,
                Town = null as string,
                District = null as string,
                Province = null as string, Strikes = 0,
                Email = null as string,
                UserName = null as string,
                Password = null as string, Status = 0, 
                PhoneNumber = 0 };
            //art and assert
            businessUser.Should().BeEquivalentTo(businessUserTest);
        }
        [Fact]
        public void BusinessUserTestEmail() 
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",0,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet",false,"Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.Email.Should().Be("walmart@gmail.com");
        }
        [Fact]
        public void BusinessUserTestUserName()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.UserName.Should().Be("walmart.cr");
        }
        [Fact]
        public void BusinessUserTestPhoneNumber()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.PhoneNumber.Should().Be(22563274);
        }
        [Fact]
        public void BusinessUserTestPassword()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.Password.Should().Be("$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.");
        }
        [Fact]
        public void BusinessUserTestStatus()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.Status.Should().Be(1);
        }
        [Fact]
        public void BusinessUserTestTown()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.Town.Should().Be("San Vicente");
        }
        [Fact]
        public void BusinessUserTestDistrict()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.District.Should().Be("Moravia");
        }
        [Fact]
        public void BusinessUserTestProvince()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.Province.Should().Be("San José");
        }
        [Fact]
        public void BusinessUserTestStrikes()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.Strikes.Should().Be(1);
        }
        [Fact]
        public void BusinessUserTestBussinesUser_Name()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.Business_Name.Should().Be("Walmart");
        }
        [Fact]
        public void BusinessUserTestLegal_Document()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            //art and assert
            businessUser.Legal_Document.Should().Be("1234567891");
        }
        [Fact]
        public void BusinessUserTestAlliance_Start()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernández",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            var dateTest = new DateTime(2022,06,30);
            //art and assert
            businessUser.Alliance_Start.Should().BeSameDateAs(dateTest);
        }
        [Fact]
        public void BusinessUserTestPerson_In_Charge()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891",new DateTime(2022,06,30),"Pedro Hernandez",
                "San Vicente","Moravia","San José",1,"walmart@gmail.com","walmart.cr", 
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",1, "Loremipsumdolorsitamet", false, "Business",22563274, "../images/Default_User.png");
            //art and assert
            businessUser.Person_In_Charge.Should().Be("Pedro Hernandez");
        }
        [Fact]
        public void BusinessUserTestInstance()
        {
            //arange
            var businessUser = new BusinessUser("Walmart", "1234567891", new DateTime(2022, 06, 30), "Pedro Hernandez",
                "San Vicente", "Moravia", "San José", 1, "walmart@gmail.com", "walmart.cr",
                "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.", 1, "Loremipsumdolorsitamet", false, "Business", 22563274, "../images/Default_User.png");
            var businessUserTest = new
            {
                Business_Name = "Walmart",
                Legal_Document = "1234567891",
                Alliance_Start = new DateTime(2022, 06, 30),
                Person_In_Charge = "Pedro Hernandez",
                Town = "San Vicente",
                District = "Moravia",
                Province = "San José",
                Strikes = 1,
                Email = "walmart@gmail.com",
                UserName = "walmart.cr",
                Password = "$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.",
                Status = 1,
                Role = "Business",
                PhoneNumber = 22563274,
                Profile_Picture = "../images/Default_User.png"
            };
            //art and assert
            businessUser.Should().BeEquivalentTo(businessUserTest);
        }
    }
}
