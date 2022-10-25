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
    public class AdministratorTests
    {
        [Fact]
        public void AdministratorNullEmail()
        {
            // Arrange
            var admin = new Administrator();

            //Act and Assert
            admin.Email.Should().BeNull();
        }

        [Fact]
        public void AdministratorNullUserName()
        {
            //Arrange
            var admin = new Administrator();

            //Act and Assert
            admin.UserName.Should().BeNull();
        }

        [Fact]
        public void AdministratorNullPassword()
        {
            //Arrange
            var admin = new Administrator();

            //Act and Assert
            admin.Password.Should().BeNull();
        }

        [Fact]
        public void AdministratorZeroPhoneNumber()
        {
            //Arrange
            var admin = new Administrator();

            //Act and Assert
            admin.PhoneNumber.Should().Be(0);
        }

        [Fact]
        public void AdministratorZeroStatus()
        {
            //Arrange
            var admin = new Administrator();

            //Act and Assert
            admin.Status.Should().Be(0);
        }


        [Fact]
        public void AdministratorValidEmail()
        {
            //Arrange

            var admin = new Administrator("foodwaste@ucr.ac.cr", "superAdmin", 88888888, "SuperAdminFW_22",
                1, "Loremipsumdolorsitamet",false ,"Admin","FoodWasteAdmin", "Juan", "Perez", "../images/Default_User.png");

            //Act and Assert
            admin.Email.Should().Be("foodwaste@ucr.ac.cr");
        }

        [Fact]
        public void AdministratorEmptyInstance()
        {
            //Arrange

            var adminTest = new { Email = null as string, UserName = null as string, PhoneNumber = 0, Password = null as string,
                Status = 0, HashedEmail = "", Anom_Preference = false, Role = null as string, AdminID = null as string, Name = null as string, LastName = null as string};

            var admin = new Administrator();

            //Act and Assert
            admin.Should().BeEquivalentTo(adminTest);
        }


        [Fact]
        public void AdministratorValidInstance()
        {
            //Arrange

            var adminTest = new { Email = "foodwaste@ucr.ac.cr", UserName = "superAdmin", PhoneNumber = 88888888, Password = "SuperAdminFW_22",
                Status = 1, HashedEmail = "Loremipsumdolorsitamet", Anom_Preference = false, Role = "Admin", AdminID = "FoodWasteAdmin", Name = "Juan", LastName = "Perez" };

            var admin = new Administrator("foodwaste@ucr.ac.cr", "superAdmin", 88888888, "SuperAdminFW_22",
                1, "Loremipsumdolorsitamet", false, "Admin", "FoodWasteAdmin", "Juan", "Perez", "../images/Default_User.png");

            //Act and Assert
            admin.Should().BeEquivalentTo(adminTest);
        }
    }
}
