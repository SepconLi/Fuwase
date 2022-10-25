/* Project includes */
using Domain.Products.DTOs;
/* System includes */
using FluentAssertions;
using Xunit;

namespace UnitTests.Domain.Products.DTOs
{
    public class FoodTypeDTOTests
    {
        [Fact]
        public void FoodtypeDTOInstance()
        {
            // arrange
            var foodtype = new FoodTypeDTO("type");
            // act
            var obj = new { Name = "type" };
            // assert
            foodtype.Should().BeEquivalentTo(obj);
        }
        [Fact]
        public void FoodtypeDTOGetName()
        {
            // arrange
            var foodtype = new FoodTypeDTO("type");
            // act
            var name = foodtype.Name;
            // assert
            name.Should().Be("type");
        }
    }
}
