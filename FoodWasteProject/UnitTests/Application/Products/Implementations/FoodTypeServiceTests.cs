using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Application.Products.Implementations;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Products.DTOs;
using Domain.Products.Entities;
using Domain.Products.Repositories;
using Moq;
using Xunit;

namespace UnitTests.Application.Products.Implementations
{
    public class FoodTypeServiceTests
    {
        private static IEnumerable<FoodTypeDTO> GetFoodTypes()
        {
            const int typeCount = 1000;
            for (int i = 0; i < typeCount; ++i)
            {
                yield return new FoodTypeDTO("type " + i.ToString());
            }
        }

        [Fact]
        public async Task GetAllFoodTypesAsyncShouldReturnFoodTypes()
        {
            // arrange
            var types = GetFoodTypes();
            var mockRepository = new Mock<IFoodTypeRepository>();
            mockRepository.Setup(x => x.GetAllFoodTypes()).ReturnsAsync(types);
            var foodTypeService = new FoodTypeService(mockRepository.Object);
            // act
            var results = await foodTypeService.GetAllFoodTypesAsync();
            // assert
            results.Should().BeEquivalentTo(types);
        }
    }
}