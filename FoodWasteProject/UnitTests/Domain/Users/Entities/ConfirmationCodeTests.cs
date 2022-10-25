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
    public class ConfirmationCodeTests
    {
        [Fact]
        public void ConfirmationCodeTestEmptyEmail()
        {
            //arange
            var confirmationCode = new ConfirmationCode();
            //art and assert
            confirmationCode.Email.Should().Be("");
        }
        [Fact]
        public void ConfirmationCodeTestEmptyCode()
        {
            //arange
            var confirmationCode = new ConfirmationCode();
            //art and assert
            confirmationCode.Code.Should().Be(0);
        }
        [Fact]
        public void ConfirmationCodeTestEmptyInstance() 
        {
            //arange
            var confirmationCode = new ConfirmationCode();
            var confirmationCodeTest = new { Email = "", Code = 0 };
            //art and assert
            confirmationCode.Should().BeEquivalentTo(confirmationCodeTest);
        }
        [Fact]
        public void ConfirmationCodeTestEmail()
        {
            //arange
            var confirmationCode = new ConfirmationCode("pedro@ucr.ac.cr",123456);
            //art and assert
            confirmationCode.Code.Should().Be(123456);
        }
        [Fact]
        public void ConfirmationCodeTestCode()
        {
            //arange
            var confirmationCode = new ConfirmationCode("pedro@ucr.ac.cr", 123456);
            //art and assert
            confirmationCode.Email.Should().Be("pedro@ucr.ac.cr");
        }
        [Fact]
        public void ConfirmationCodeTestInstance()
        {
            //arange
            var confirmationCode = new ConfirmationCode("pedro@ucr.ac.cr", 123456);
            var confirmationCodeTest = new { Email = "pedro@ucr.ac.cr", Code = 123456 };
            //art and assert
            confirmationCode.Should().BeEquivalentTo(confirmationCodeTest);
        }
    }
}
