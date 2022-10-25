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
    public class ProductTypeServiceTests
    {
        private static IEnumerable<ProductType> GetProductTypes()
        {
            throw new System.NotImplementedException();
        }

        /*
        [Fact]
        public async Task GetProductTypesAsyncShouldReturnProductTypes()
        {
            // arrange
            // act
            // assert
        }
        */
    }
}