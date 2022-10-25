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
    public class TownTests
    {
        [Fact]
        public void TownTestEmptyName()
        {
            // Arrange
            var town = new Town();

            // Act and assert
            town.Name.Should().Be("");

        }
        [Fact]
        public void LocationInstance()
        {
            //arrange
            var locationTest = new { Name = "Alajuela", PName = "Alajuela", DName = "Alajuela" };
            var location = new Location("Alajuela", "Alajuela", "Alajuela");
            //act and assert
            location.Should().BeEquivalentTo(locationTest);
        }
    }
}
