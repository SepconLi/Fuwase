/* Project includes */
using Domain.Locations.Entities;
/* System includes */
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Locations.Entities
{
    public class ProvinceTests
    {
        [Fact]
        public void ProvinceTestEmptyName()
        {
            // Arrange
            var province = new Province();

            // Act and assert
            province.Name.Should().Be("");

        }
        [Fact]
        public void ProvinceInstanceTest()
        {
            var provinceTest = new { Name = "Alajuela" };
            var province = new Province("Alajuela");
            province.Should().BeEquivalentTo(provinceTest);
        }
    }
}
