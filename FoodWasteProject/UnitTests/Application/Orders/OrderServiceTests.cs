using Application.Orders;
using Application.Orders.Implementations;
using Domain.Orders.Repositories;
using Domain.Orders.Entities;
using Domain.Orders.DTOs;
using Domain.Donations.Entities;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using Infrastructure.Users.Repositories;
using Infrastructure.Orders.Repositories;

using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Application.Donations.Implementations;
using Application.Products;
using Application.Donations;
using Domain.Products.Repositories;
using Domain.Products.Entities;

namespace UnitTests.Application.Orders
{
    public class OrderServiceTests
    {

        [Fact]
        public async Task addOrderTest()
        {
            // Arrange
            Mock<Order> testOrder = new Mock<Order>();

            Mock<IOrderRepository> testRepository = new Mock<IOrderRepository>();
            testRepository.Setup(t => t.AddOrder(testOrder.Object)).ReturnsAsync(15);

            var testService = new OrderService(testRepository.Object);
            // Act and assert
            var result = await testService.AddOrderAsync(testOrder.Object);
            result.Should().Be(15);
        }
        [Fact]
        public async Task AddOrderAsyncReturnsValidID()
        {

            var testOrderRepository = new Mock<IOrderRepository>();
            var testService = new OrderService(testOrderRepository.Object);
            var testOrder = new Mock<Order>(15, "P", "donador", "beneficiario");
            // Act and assert
            var result = await testService.AddOrderAsync(testOrder.Object);
            result.Should().BeGreaterThanOrEqualTo(0);
        }
        [Fact]
        public async Task OrderServiceTestCreatesSuccesfully()
        {
            // Arrange
            var testOrderRepository = new Mock<IOrderRepository>();
            var testProductService = new Mock<IProductService>();
            var testDonationService = new Mock<IDonationService>();
            var testOrderProductService = new Mock<IOrderProductService>();
            OrderService orderService = new OrderService(testOrderRepository.Object, testProductService.Object, testDonationService.Object, testOrderProductService.Object);

            // Act and assert

            orderService.Should().NotBeNull();

        }

        [Fact]
        public async Task GetInformationBusinessAsyncReturnsValidList()
        {
            // Arrange
            Mock<Order> testOrder = new Mock<Order>();
            var testInformation = new Mock<InformacionDTO>();
            IList<InformacionDTO> listTest = new List<InformacionDTO>();
            var testRepository = new Mock<IOrderRepository>();
            testRepository.Setup(t => t.getInformationBusiness()).ReturnsAsync(listTest);


            // Act and  assert
            var testService = new OrderService(testRepository.Object);

            var result = await testService.getInformationBusinessAsync();
            result.Should().NotBeNull(); 

        }
        [Fact]
        public async Task getOrderByIdShouldReturnOrder()
        {
            //arrange
            const int id = 1;
            var order = new Order(id, "P", "ramirezjosher@gmial.com", "david.rojasobando@gmail.com");
            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(repo =>
            repo.GetOrderById(id)).ReturnsAsync(order);
            var orderService = new OrderService(mockOrderRepository.Object);
            //act
            var result = await orderService.GetOrderByIdAsync(id);
            //assert
            result.Should().Be(order);
        }
        [Fact]
        public async Task getInformationPersonalReturnsValidList()
        {
            IList<InformacionDTO> listTest = new List<InformacionDTO>();
            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(t => t.getInformationPersonal()).ReturnsAsync(listTest);
            var orderService = new OrderService(mockOrderRepository.Object);
            //act 
            var listPersonalUsers = await orderService.getInformationPersonalAsync();
            //assert 
            listPersonalUsers.Should().NotBeNull();

        }
        [Fact]
        public async Task GetOrderAsyncReturnsValidItem()
        {
            var mockOrder = new Mock<Order>();
            var mockOrderRepository = new Mock<IOrderRepository>();
            IList<Order> listTest = new List<Order>();
            listTest.Add(mockOrder.Object);
            mockOrderRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(listTest);
            var orderService = new OrderService(mockOrderRepository.Object);
            //act
            var result = await orderService.GetOrderAsync();
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public async Task getAnonInformationAsyncReturnsValidList()
        {
            IList<InformacionDTO> listTest = new List<InformacionDTO>();
            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(t => t.getAnonInformation()).ReturnsAsync(listTest);
            var orderService = new OrderService(mockOrderRepository.Object);
            // act
            var result = await orderService.getAnonInformationAsync();
            // assert
            result.Should().NotBeNull();
        }
        [Fact]
        public async Task getInformationByEmailReturnsInformationSuccesfully()
        {
            var testInformation = new Mock<InformacionDTO>("ramirezjosher@gmail.com","Josher","Ramirez");
            IList<InformacionDTO> listTest = new List<InformacionDTO>();
            listTest.Add(testInformation.Object);
            var mockOrderRepository = new Mock<IOrderRepository>();
            var orderService = new OrderService(mockOrderRepository.Object);
            string expectedResult = "Josher Ramirez";
            //act
            var result = await orderService.getInformationByEmail("ramirezjosher@gmail.com", listTest);
            // assert
            result.Should().BeEquivalentTo(expectedResult);
        }
        [Fact]
        public async Task getInformationByEmailUnknown()
        {
            var testInformation = new Mock<InformacionDTO>("ramirezjosher@gmail.com", "Josher", "Ramirez");
            IList<InformacionDTO> listTest = new List<InformacionDTO>();
            listTest.Add(testInformation.Object);
            var mockOrderRepository = new Mock<IOrderRepository>();
            var orderService = new OrderService(mockOrderRepository.Object);
            string expectedResult = "Desconocido";
            //act
            var result = await orderService.getInformationByEmail("david.rojasobando@ucr.ac.cr", listTest);
            // assert
            result.Should().BeEquivalentTo(expectedResult);
        }
        [Fact]
        public async Task CreateOrderAsyncOneProduct()
        {
            var order = new Mock<Order>("P","donador","beneficiario");
            List<Restriction> restrictions = new List<Restriction>();
            byte[] data = new byte[0];
            var donationTest = new Mock<Donation>("San Jose","Central","San Francisco de dos ríos","150mts","descripcion","ramirezjosher@gmail.com");
            var product = new Mock<Product>("Arroz", "Grano", "Grano", System.DateTime.Now,1, 1000.0, donationTest.Object,data,"tio pelon",restrictions,1);
            List<Product> productsList = new List<Product>();
            productsList.Add(product.Object);
            List<int> selectedCuantities = new List<int> { 1 };
            var mockOrderRepository = new Mock<IOrderRepository>();
            var mockProductRepository = new Mock<IProductService>();
            var mockDonationService = new Mock<IDonationService>();
            var mockProductOrderService = new Mock<IOrderProductService>();
            mockOrderRepository.Setup(x => x.AddOrder(order.Object)).ReturnsAsync(1);
            var orderService = new OrderService(mockOrderRepository.Object,mockProductRepository.Object,mockDonationService.Object,mockProductOrderService.Object);
            
            // act
            var result = await orderService.CreateOrderAsync(order.Object, productsList, selectedCuantities);
            // assert
            result.Should().BeGreaterThanOrEqualTo(0);
        }
    }
}
