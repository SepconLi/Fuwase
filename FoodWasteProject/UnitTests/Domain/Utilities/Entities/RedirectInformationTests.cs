using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Project imports
using Domain.Utilities.Entities;
//Nugets imports
using Xunit;
using FluentAssertions;

namespace UnitTests.Domain.Utilities.Entities
{
    public class RedirectInformationTests
    {
        [Fact]
        public void RedirectInformationEmptyRoute()
        {
            //arange
            var info = new RedirectInformation();
            //act and assert
            info.Route.Should().BeNull();
        }
        [Fact]
        public void RedirectInformationEmptyEmail()
        {
            //arange
            var info = new RedirectInformation();
            //act and assert
            info.Email.Should().BeNull();
        }
        [Fact]
        public void RedirectInformationEmptyParam()
        {
            //arange
            var info = new RedirectInformation();
            //act and assert
            info.Param.Should().BeNull();
        }
        [Fact]
        public void RedirectInformationEmptyKey()
        {
            //arange
            var info = new RedirectInformation();
            //act and assert
            info.Key.Should().BeNull();
        }
        [Fact]
        public void RedirectInformationEmptyHash()
        {
            //arange
            var info = new RedirectInformation();
            //act and assert
            info.Hash.Should().BeNull();
        }
        [Fact]
        public void RedirectInformationEmptyExpiration()
        {
            //arange
            var info = new RedirectInformation();
            //act and assert
            info.Hash.Should().BeNullOrEmpty();
        }
        [Fact]
        public void RedirectInformationCheckRoute()
        {
            //arange
            var info = new RedirectInformation("/","test@gmail.com", "test");
            //act and assert
            info.Route.Should().Be("/");
        }
        [Fact]
        public void RedirectInformationCheckEmail()
        {
            //arange
            var info = new RedirectInformation("/", "test@gmail.com", "test");
            //act and assert
            info.Email.Should().Be("test@gmail.com");
        }
        [Fact]
        public void RedirectInformationCheckParam()
        {
            //arange
            var info = new RedirectInformation("/", "test@gmail.com", "test");
            //act and assert
            info.Param.Should().Be("test");
        }
        [Fact]
        public void RedirectInformationCheckKey()
        {
            //arange
            var info = new RedirectInformation("/", "test@gmail.com", "test");
            //act and assert
            info.Key.Should().NotBeNull();
        }
        [Fact]
        public void RedirectInformationCheckHash()
        {
            //arange
            var info = new RedirectInformation("/", "test@gmail.com", "test");
            //act and assert
            info.Hash.Should().NotBeNull();
        }
        [Fact]
        public void RedirectInformationCheckExpiration()
        {
            //arange
            var info = new RedirectInformation("/", "test@gmail.com", "test");
            //act and assert
            info.Expiration.Should().Be(DateTime.Today.AddDays(1));
        }
        [Fact]
        public void RedirectInformationVerifyExpirationDateShouldBeFalse()
        {
            //arange
            var info = new RedirectInformation("/", "test@gmail.com", "test");
            //act
            var result = info.VerifyExpirationDate();
            //assert
            result.Should().Be(false);
        }

        [Fact]
        public void RedirectInformationVerifyExpirationDateShouldBeTrue()
        {
            //arange
            var info = new RedirectInformation("/", "test@gmail.com", "test");
            info.Expiration = DateTime.Today;
            //act
            var result = info.VerifyExpirationDate();
            //assert
            result.Should().Be(true);
        }
    }
}
