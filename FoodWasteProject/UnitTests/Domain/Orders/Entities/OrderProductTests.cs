using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Domain.Orders.Entities;
using Domain.Core.ValueObjects;
using Domain.Core.Helpers;

namespace UnitTests.Domain.Orders.Entities
{
    public class UserFoodPreferencesTests
    {
        [Fact]
        public void OrderProductTestEmptyOrderId()
        {
            //Arrange
            var orderProduct = new OrderProduct();
            // Act and assert
            orderProduct.OrderId.Should().Be(0);
        }

        [Fact]
        public void OrderProductTestEmptyOrder()
        {
            //Arrange
            var orderProduct = new OrderProduct();
            // Act and assert
            orderProduct.Order.Should().Be(null);
        }

        [Fact]
        public void OrderProductTestEmptyProductId()
        {
            OrderProduct orderProduct = new OrderProduct();
            orderProduct.ProductId.Should().Be(0);
        }

        [Fact]
        public void OrderProductTestEmptyProduct()
        {
            //Arrange
            var orderProduct = new OrderProduct();
            // Act and assert
            orderProduct.Product.Should().Be(null);
        }

        [Fact]
        public void OrderProductTestEmptyQuantity()
        {
            OrderProduct orderProduct = new OrderProduct();
            orderProduct.Quantity.Should().Be(0);
        }

        [Fact]
        public void OrderProductTestEmptyInstance()
        {
            // Arrange
            var orderProductTest = new { OrderId = 0, ProductName = "", DonationId = 0, Quantity = 0 };
            var orderProduct = new OrderProduct();

            //Act and assert
            orderProduct.Should().BeEquivalentTo(orderProductTest);
        }

        [Fact]
        public void OrderProductTestOrderId()
        {
            // arrange
            var orderProduct = new OrderProduct(45, 3, 5);

            // act and assert
            orderProduct.OrderId.Should().Be(45);
        }

        [Fact]
        public void OrderProductTestProductName()
        {
            // arrange
            var orderProduct = new OrderProduct(45, 3, 5);

            // act and assert
            orderProduct.ProductId.Should().Be(3);
        }

        [Fact]
        public void OrderProductTestQuantity()
        {
            // arrange
            var orderProduct = new OrderProduct(45, 3, 5);

            // act and assert
            orderProduct.Quantity.Should().Be(5);
        }

        [Fact]
        public void OrderProductTestInstance()
        {
            // arrange
            var orderProductTest = new { OrderId = 45, ProductId = 3, Quantity = 5 };
            var orderProduct = new OrderProduct(45,3,5);

            // act and assert
            orderProduct.Should().BeEquivalentTo(orderProductTest);
        }
    }
}
