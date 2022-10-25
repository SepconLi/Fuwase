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
    public class PersonalUserTests
    {
        [Fact]
        public void PersonalUserNullIdNumber()
        {
            //Arrange
            var personalUser = new PersonalUser();

            //Act and Assert
            personalUser.IdNumber.Should().BeNull();
        }
        [Fact]
        public void PersonalUserNullName()
        {
            //Arrange
            var personalUser = new PersonalUser();

            //Act and Assert
            personalUser.Name.Should().BeNull();
        }
        [Fact]
        public void PersonalUserNullLastName()
        {
            //Arrange
            var personalUser = new PersonalUser();

            //Act and Assert
            personalUser.LastName.Should().BeNull();
        }
        [Fact]
        public void PersonalUserValidIdNumber()
        {
            //Arrange
            var personalUser = new PersonalUser("111111111", "Anastacio", "Rodriguez", "ana_rodri@gmail.com", 
                "xXAnastacioXx", 66666666, "Patito.20", 1, "Loremipsumdolorsitamet", false,"Personal","Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            //Act and Assert
            personalUser.IdNumber.Should().Be("111111111");
        }
        [Fact]
        public void PersonalUserValidName()
        {
            //Arrange
            var personalUser = new PersonalUser("111111111", "Anastacio", "Rodriguez", "ana_rodri@gmail.com",
                "xXAnastacioXx", 66666666, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            //Act and Assert
            personalUser.Name.Should().Be("Anastacio");
        }

        [Fact]
        public void PersonalUserValidLastName()
        {
            //Arrange
            var personalUser = new PersonalUser("111111111", "Anastacio", "Rodriguez", "ana_rodri@gmail.com",
                "xXAnastacioXx", 66666666, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            //Act and Assert
            personalUser.LastName.Should().Be("Rodriguez");
        }

        [Fact]
        public void PersonalUserValidTown()
        {
            //Arrange
            var personalUser = new PersonalUser("111111111", "Anastacio", "Rodriguez", "ana_rodri@gmail.com",
                "xXAnastacioXx", 66666666, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            //Act and Assert
            personalUser.Town.Should().Be("Santa Cruz");
        }


        [Fact]
        public void PersonalUserValidDistrict()
        {
            //Arrange
            var personalUser = new PersonalUser("111111111", "Anastacio", "Rodriguez", "ana_rodri@gmail.com",
                "xXAnastacioXx", 66666666, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            //Act and Assert
            personalUser.District.Should().Be("Santa Cruz");
        }

        [Fact]
        public void PersonalUserValidProvince()
        {
            //Arrange
            var personalUser = new PersonalUser("111111111", "Anastacio", "Rodriguez", "ana_rodri@gmail.com",
                "xXAnastacioXx", 66666666, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            //Act and Assert
            personalUser.Province.Should().Be("Guanacaste");
        }

        [Fact]
        public void PersonalUserValidStrikes()
        {
            //Arrange
            var personalUser = new PersonalUser("111111111", "Anastacio", "Rodriguez", "ana_rodri@gmail.com",
                "xXAnastacioXx", 66666666, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            //Act and Assert
            personalUser.Strikes.Should().Be(0);
        }

        [Fact]
        public void PersonalUserNullInstance()
        {
            //Arrange

            var personalUser = new PersonalUser();

            var personalUserTest = new
            {
                IdNumber = null as string,
                Name = null as string,
                LastName = null as string,
                Email = null as string,
                UserName = null as string,
                PhoneNumber = 00000000,
                Password = null as string,
                Status = 0,
                Town = null as string,
                District = null as string,
                Province = null as string,
                Strikes = 0,
                Profile_Picture = null as string
            };


            //Act and Assert
            personalUser.Should().BeEquivalentTo(personalUserTest);
        }

        [Fact]
        public void PersonalUserValidInstance()
        {
            //Arrange
            var personalUser = new PersonalUser("111111111", "Anastacio", "Rodriguez", "ana_rodri@gmail.com",
                "xXAnastacioXx", 66666666, "Patito.20", 1, "Loremipsumdolorsitamet", false, "Personal", "Santa Cruz", "Santa Cruz", "Guanacaste", 0, "../images/Default_User.png");

            var personalUserTest = new
            {
                IdNumber = "111111111",
                Name = "Anastacio",
                LastName = "Rodriguez",
                Email = "ana_rodri@gmail.com",
                UserName = "xXAnastacioXx",
                PhoneNumber = 66666666,
                Password = "Patito.20",
                Status = 1,
                Town = "Santa Cruz",
                District = "Santa Cruz",
                Province = "Guanacaste",
                Strikes = 0,
                Profile_Picture = "../images/Default_User.png"
            };


            //Act and Assert
            personalUser.Should().BeEquivalentTo(personalUserTest);
        }
    }
}
