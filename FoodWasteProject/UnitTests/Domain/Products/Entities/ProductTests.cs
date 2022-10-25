/**
 * ALV-DO-1.2. Register product name, brand, due date, amount, and weight
 * Participants:
 * Rodrigo Li Qiu
 * Daniela Murillo Alvarado
 * Jimena Gdur Vargas
 * PIB22I02-400 Testing
 **/


/* Project includes */
using Domain.Products.Entities;
using Domain.Donations.Entities;
using Domain.Orders.Entities;
/* System includes */
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Products.Entities
{
    public class ProductTests
    {
        /* Methods for other getting other classes */
        private static List<Restriction> GetRestrictionList()
        {
            List<Restriction> restrictions = new List<Restriction>();
            return restrictions;
        }
        private static List<OrderProduct> GetOrderProductList()
        {
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            return orderProducts;
        }

        private static Donation GetDonation()
        {
            Donation donation = new Donation();
            return donation;
        }

        /* Tests for empty constructor */

        [Fact]
        public void ProductTestEmptyConstructor()
        {
            // Arrange
            var product = new Product();

            // Act and assert
            product.Name.Should().Be("");
            product.FoodType.Should().Be("");
            product.ProductType.Should().Be("");
            product.Quantity.Should().Be(0);
            product.Weight.Should().Be(0.0);
            product.Brand.Should().Be("");
            product.Image.Should().BeNullOrEmpty();
            product.OrderId.Should().BeNull();
            product.Donation.Should().BeNull();
        }


        [Fact]
        public void ProductTestEmptyOrderProductList()
        {
            // Arrange
            var product = new Product();
            List<OrderProduct> orderProducts = new List<OrderProduct>();

            // Act and assert
            product.OrderProducts.Should().BeEquivalentTo(orderProducts);

        }

        [Fact]
        public void ProductTestEmptyRestrictionList()
        {
            // Arrange
            var product = new Product();
            List<Restriction> restrictions = new List<Restriction>();

            // Act and assert
            product.Restrictions.Should().BeEquivalentTo(restrictions);

        }

        [Fact]
        public void ProductTestEmptyInstance()
        {
            // arrange
            var productTest = new { Name = "", FoodType = "", ProductType = "", Quantity = 0, Weight = 0.0, Brand = "" };

            var product = new Product();

            // act and assert
            product.Should().BeEquivalentTo(productTest);
        }

        /* Tests for basic constructor */

        [Fact]
        public void ProductTestWithData()
        {
            // Arrange
            var product = new Product("name", "foodtype", "prodType", 1, 2.5, "brand");


            // Act and assert
            product.Name.Should().Be("name");
            product.FoodType.Should().Be("foodtype");
            product.ProductType.Should().Be("prodType");
            product.Quantity.Should().Be(1);
            product.Weight.Should().Be(2.5);
            product.Brand.Should().Be("brand");
        }

        [Fact]
        public void ProductTestOrderProductList()
        {
            // Arrange
            var product = new Product("name", "foodtype", "prodType", 1, 2.5, "brand");

            // Act and assert
            product.OrderProducts.Should().BeEquivalentTo(GetOrderProductList());

        }

        [Fact]
        public void ProductTestRestrictionList()
        {
            // Arrange
            var product = new Product("name", "foodtype", "prodType", 1, 2.5, "brand");

            // Act and assert
            product.Restrictions.Should().BeEquivalentTo(GetRestrictionList());

        }

        [Fact]
        public void ProductTestInstance()
        {
            // arrange
            var productTest = new { Name = "name", FoodType = "foodtype", ProductType = "prodType", Quantity = 1, Weight = 2.5, Brand = "brand" };

            var product = new Product("name", "foodtype", "prodType", 1, 2.5, "brand");

            // act and assert
            product.Should().BeEquivalentTo(productTest);
        }

        /* Tests for complex constructor */

        [Fact]
        public void ProductTestWithNameComplex()
        {
            // Arrange
            byte[] image = Array.Empty<Byte>();
            var product = new Product("name", "foodtype", "prodType", DateTime.Today, 1, 2.5, GetDonation(), image, "brand", GetRestrictionList(), 1);

            // Act and assert
            product.Name.Should().Be("name"); product.Name.Should().Be("name");
            product.FoodType.Should().Be("foodtype");
            product.ProductType.Should().Be("prodType");
            product.Quantity.Should().Be(1);
            product.Weight.Should().Be(2.5);
            product.Brand.Should().Be("brand");
            product.ExpirationDate.Should().Be(DateTime.Today);
            product.Image.Should().BeEquivalentTo(image);
            product.DonationId.Should().Be(1);
        }

        [Fact]
        public void ProductTestInstanceComplex()
        {
            // arrange
            var productTest = new { Name = "name", FoodType = "foodtype", ProductType = "prodType", Quantity = 1, Weight = 2.5, Brand = "brand" };

            var product = new Product("name", "foodtype", "prodType", 1, 2.5, "brand");

            // act and assert
            product.Should().BeEquivalentTo(productTest);
        }

    }
}
