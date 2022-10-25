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
    public class ProductTypeTests
    {
        [Fact]
        public void ProductTypeTestEmptyName()
        {
            // Arrange
            var productType = new ProductType();

            // Act and assert
            productType.Name.Should().Be("");

        }

        [Fact]
        public void ProductTypeTestName()
        {
            // Arrange
            var productType = new ProductType("name");

            // Act and assert
            productType.Name.Should().Be("name");

        }

        [Fact]
        public void ProductTypeTestEmptyInstance()
        {
            // arrange
            var productTypeTest = new { Name = "" };

            var productType = new ProductType();

            // act and assert
            productType.Should().BeEquivalentTo(productTypeTest);
        }

        [Fact]
        public void ProductTypeTestInstance()
        {
            // arrange
            var productTypeTest = new { Name = "name" };

            var productType = new ProductType("name");

            // act and assert
            productType.Should().BeEquivalentTo(productTypeTest);
        }
    }
}
