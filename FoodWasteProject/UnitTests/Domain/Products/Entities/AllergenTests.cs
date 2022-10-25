/* Project includes */
using Domain.Products.Entities;
/* System includes */
using FluentAssertions;
using Xunit;

/*This tests correspond to the Allergen repository and were made by Daniela Murillo */

namespace UnitTests.Domain.Products.Entities
{
    public class AllergenTests
    {
        //Testing null values in empty constructor
        [Fact]
        public void AllergenTestEmptyConstructor()
        {
            // Arrange
            var allergen = new Allergen();

            // Act and assert
            allergen.Name.Should().Be("");
            allergen.Description.Should().Be("");
            allergen.Category.Should().Be("");

        }

        //Testing attributes with valid values in full constructor
        [Fact]
        public void AllergenTestFullConstructor()
        {
            // Arrange
            var allergen = new Allergen("name", "description", "category");

            // Act and assert
            allergen.Name.Should().Be("name");
            allergen.Description.Should().Be("description");
            allergen.Category.Should().Be("category");

        }

        //Testing the empty constructor
        [Fact]
        public void AllergenTestEmptyInstance()
        {
            // arrange
            var allergenTest = new { Name = "", Description = "", Category = "" };

            var allergen = new Allergen();

            // act and assert
            allergen.Should().BeEquivalentTo(allergenTest);
        }

        //Testing the full constructor 
        [Fact]
        public void AllergenTestInstance()
        {
            // arrange
            var allergen = new Allergen("name", "description", "category");
            var allergenTest = new { Name = "name", Description = "description", Category = "category" };

            // act and assert
            allergen.Should().BeEquivalentTo(allergenTest);
        }
    }
}







