using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

using Application.Products.Implementations;
using Application.Products;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Products.DTOs;
using Domain.Products.Entities;
using Domain.Products.Repositories;


/*This tests correspond to the Allergen repository and were made by Daniela Murillo */

namespace UnitTests.Application.Products.Implementations
{
    public class AllergenServiceTests
    {
        //Creating category mock list to test methods
        private static IEnumerable<AllergenCategory> GetCategoryList()
        {
            const int categoriesCount = 3;
            for (int i = 0; i < categoriesCount; ++i)
            {
                yield return new AllergenCategory("Category" + i.ToString(), "Icon" + i.ToString());
            }
        }

        //Creating allergen mock list to test methods
        private static IEnumerable<Allergen> GetAllergenList()
        {
            const int categoriesCount = 3;
            for (int i = 0; i < categoriesCount; ++i)
            {
                yield return new Allergen("Allergen" + i.ToString(), "Description" + i.ToString(), "Category" + i.ToString());
            }
        }

        //Testing the getCategories method. It should return the list created before.
        [Fact]
        public async Task GetCategoriesAsync()
        {
            // arrange
           var categories = GetCategoryList().ToList();
            var mockAllergenRepository = new Mock<IAllergenRepository>();
            mockAllergenRepository.Setup(repo => 
            repo.GetCategories()).ReturnsAsync(categories);
            var allergenService = new AllergenService(mockAllergenRepository.Object);
            // act
            var results = await allergenService.GetCategoriesAsync();
            // assert
            results.Should().BeEquivalentTo(categories);
        }

        //Testing the getCategories method with valid category name.
        //It should return the list created before. Happy path.
        [Fact]
        public async Task GetAllergenByValidCategoryAsync()
        {
            // arrange
            var categories = GetAllergenList().ToList();
            string categoryName = "Category1";
            var mockAllergenRepository = new Mock<IAllergenRepository>();
            mockAllergenRepository.Setup(repo =>
            repo.GetAllergenByCategory(categoryName)).ReturnsAsync(categories);
            var allergenService = new AllergenService(mockAllergenRepository.Object);
            // act
            var results = await allergenService.GetAllergenByCategoryAsync(categoryName);
            // assert
            results.Should().BeEquivalentTo(categories);
        }

        //Testing the getCategories method with invalid category name.
        //It should return an empty list because the category doesn't exist. Sad path.
        [Fact]
        public async Task GetAllergenByInvalidCategoryAsync()
        {
            // arrange
            var categories = GetAllergenList().ToList();
            string categoryName = "Nosoyunacategoria";
            var mockAllergenRepository = new Mock<IAllergenRepository>();
            mockAllergenRepository.Setup(repo =>
            repo.GetAllergenByCategory(categoryName));
            var allergenService = new AllergenService(mockAllergenRepository.Object);
            // act
            var results = await allergenService.GetAllergenByCategoryAsync(categoryName);
            // assert
            results.Should().BeEmpty();
        }

    }
}