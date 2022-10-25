using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using FluentAssertions;
using Application.Orders.Implementations;
using Domain.Orders.Repositories;
using Domain.Products.Entities;
using Domain.Orders.Entities;
using Domain.Products.Repositories;
using Application.Products.Implementations;

namespace UnitTests.Application.Orders
{
    public class TestsOrderProductService
    {

        [Fact]
        public async Task AddOrderProductTest()
        {
            //arrange
            const int productId = 0;
            var product = new OrderProduct();
            var mockOrderProductRepository = new Mock<IOrderProductRepository>();
            var mockProduct = new Mock<IProductRepository>();
            var productService = new ProductService(mockProduct.Object);
            mockOrderProductRepository.Setup(repo => repo.getOrderProductsByOrderId(productId));
            var orderProductService = new OrderProductService(mockOrderProductRepository.Object, productService);

            //act
            await orderProductService.AddOrderProduct(product);

            //assert
            product.Order.Should().Be(null);
            product.Product.Should().Be(null);
            product.OrderId.Should().Be(0);
            product.ProductId.Should().Be(0);
            product.Quantity.Should().Be(0);
        }

        [Fact]
        public async Task getOrderProductsByOrderIdTest()
        {
            //arrange
            //var product = new Product("Leche", "Lacteo", "Lacteo",4, 500.0, "Dos Pinos");
            var order = new Order(1,"P","ejemplo@gmail.com", "ejemplo3@gmail.com");
            //order.Id = 1;
            var orderProduct = new OrderProduct(order.Id, 0, 4);
            IList<OrderProduct> orderProducts = new List<OrderProduct>();
            orderProducts.Add(orderProduct);
            var mockOrderProductRepository = new Mock<IOrderProductRepository>();
            var mockProduct = new Mock<IProductRepository>();
            var productService = new ProductService(mockProduct.Object);
            mockOrderProductRepository.Setup(repo => repo.getOrderProductsByOrderId(order.Id)).ReturnsAsync(orderProducts);

            var orderProductService = new OrderProductService(mockOrderProductRepository.Object, productService);

            //act
            var result = await orderProductService.getOrderProductsByOrderId(order.Id);

            //assert
            for (int i=0; i<orderProducts.Count(); i++)
            {
                result[i].Should().Be(orderProducts[i]);
            }
        }

        /*
        [Fact]
        public async Task ModifyOrderProductTest()
        {
            //arrange
            var order = new Order(1, "P", "ejemplo@gmail.com", "ejemplo3@gmail.com");
            var orderProduct = new OrderProduct(order.Id, "Cereal", 1, 4);
            var replaceOrderProduct = new OrderProduct(order.Id, "Cereal", 1, 8);
            IList<OrderProduct> orderProducts = new List<OrderProduct>();
            orderProducts.Add(orderProduct);
            var mockOrderProductRepository = new Mock<IOrderProductRepository>();
            var mockProduct = new Mock<IProductRepository>();
            var productService = new ProductService(mockProduct.Object);
            mockOrderProductRepository.Setup(repo => repo.AddOrderProduct(orderProduct));
            mockOrderProductRepository.Setup(repo => repo.ModifyOrderProduct(replaceOrderProduct));
            mockOrderProductRepository.Setup(repo => repo.getOrderProductsByOrderId(order.Id)).ReturnsAsync(orderProducts);
            var orderProductService = new OrderProductService(mockOrderProductRepository.Object, productService);

            //act
            await orderProductService.AddOrderProduct(orderProduct);
            await orderProductService.ModifyOrderProduct(replaceOrderProduct);
            var result = await orderProductService.getOrderProductsByOrderId(order.Id);

            //assert
            result[0].Should().Be(replaceOrderProduct);
        }
        */
    }
}
