/* Project includes */
using Domain.Products.Entities;
/* System includes */
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Products.Entities
{
    public class FoodTypeTests
    {
        [Fact]
        public void FoodTypeEmptyInstance()
        {
            //arrange
            var foodType = new FoodType();
            var obj = new { Name = "" };
            // act and assert
            foodType.Should().BeEquivalentTo(obj);
        }
        [Fact]
        public void FoodTypeInstance()
        {
            //arrange
            var foodType = new FoodType("type");
            var obj = new { Name = "type" };
            // act and assert
            foodType.Should().BeEquivalentTo(obj);
        }
        [Fact]
        public void FoodTypeGetTest()
        {
            //arrange
            var foodType = new FoodType("type");
            // act 
            string test = foodType.Name;
            // assert
            test.Should().Be("type");
        }
    }
}
