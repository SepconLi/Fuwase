/* Project includes */
using Domain.Products.Entities;
/* System includes */
using FluentAssertions;
using Xunit;

/*This tests correspond to the Allergen repository and were made by Daniela Murillo */

namespace UnitTests.Domain.Products.Entities
{
    public class AllergenCategoryCategoryTests
    {
        //Testing null values in empty constructor
        [Fact]
        public void AllergenCategoryCategoryTestEmptyConstructor()
        {
            // Arrange
            var allergenCategory = new AllergenCategory();

            // Act and assert
            allergenCategory.Name.Should().Be("");
            allergenCategory.Icon.Should().Be("");

        }

        //Testing attributes with valid values in full constructor
        [Fact]
        public void AllergenCategoryCategoryTestFullConstructor()
        {
            // Arrange
            var allergenCategory = new AllergenCategory("name", "icon");

            // Act and assert
            allergenCategory.Name.Should().Be("name");
            allergenCategory.Icon.Should().Be("icon");

        }

        //Testing the empty constructor
        [Fact]
        public void AllergenCategoryTestEmptyInstance()
        {
            // arrange
            var allergenCategoryTest = new { Name = "", Icon = "" };

            var allergenCategory = new AllergenCategory();

            // act and assert
            allergenCategory.Should().BeEquivalentTo(allergenCategoryTest);
        }

        //Testing the full constructor 
        [Fact]
        public void AllergenCategoryCategoryTestInstance()
        {
            // arrange
            var allergenCategory = new AllergenCategory("name", "icon");
            var allergenCategoryTest = new { Name = "name", Icon = "icon" };

            // act and assert
            allergenCategory.Should().BeEquivalentTo(allergenCategoryTest);
        }
    }
}