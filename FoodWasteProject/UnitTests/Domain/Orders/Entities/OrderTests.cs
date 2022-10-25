using Domain.Orders.Entities;

using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Orders.Entities
{
    public class OrderTests
    {
        [Fact]
        public void OrderTestEmptyDonorId()
        {
            Order order = new Order();
            order.DonorId.Should().Be(null);
        }

        [Fact]
        public void OrderTestEmptyOrderStatus()
        {
            Order order = new Order();
            order.OrderStatus.Should().NotBeNull();
        }

        [Fact]
        public void OrderTestEmptyRecipientId()
        {
            Order order = new Order();
            order.RecipientId.Should().Be(null);
        }
    
        [Fact]
        public void CreateOrderInstance()
        {
            var ordertest = new { OrderStatus="P", DonorId = "donador", RecipientId = "beneficiario", _orderProducts = new List<OrderProduct>() };
            // Arrange
            Order order = new Order("P", "donador", "beneficiario");

            // Act and assert

            order.Should().BeEquivalentTo(ordertest);
        }

        [Fact]
        public void CreateOrderWithID()
        {
            // Arrange
            Order order = new Order(15, "P", "donador", "beneficiario");

            // Act and assert
            order.Id.Should().Be(15);
        }

    }
}
    


