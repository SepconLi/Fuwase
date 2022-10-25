using Domain.Orders.Entities;
using Domain.Orders.Repositories;
using Application.Orders.Implementations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace UnitTests.Application.Orders
{
    public class TestOrderService
    {
        [Fact]
        public async Task GetOrderByIdAsyncTest()
        {
            // arrange
            const int id = 1;
            var order = new Order(id:id,"P", "gilbertma2000@gmail.com", "maeva@ucr.ac.cr" );
            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(repo => repo.GetOrderById(id)).ReturnsAsync(order);
            var orderService = new OrderService(mockOrderRepository.Object);
            // act
            var result = await orderService.GetOrderByIdAsync(id);
            // assert
            result.Should().Be(order);
        }
    }
}