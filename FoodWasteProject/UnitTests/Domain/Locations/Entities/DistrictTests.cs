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

namespace UnitTests.Domain.Donations.Entities
{
    public class DistrictTests
    {
        [Fact]
        public void DistrictTestEmptyName()
        {
            // Arrange
            var district = new District();

            // Act and assert
            district.Name.Should().Be("");

        }
        [Fact]
        public void DistrictInstanceTest()
        {
            var districtTest = new { Name = "Alvarado" , PName = "Cartago"};
            var district = new District("Alvarado","Cartago");
            district.Should().BeEquivalentTo(districtTest);
        }
    }
}
