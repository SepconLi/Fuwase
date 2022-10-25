/*
	Las historias trabajadas estan relacionadas a historias que ya han sido aprobadas en sprintas anterores entonces no tenemos el Id específico de las historias
	Las personas que trabajaron en esta actividad son: Milen Rodriguez Man y Jorim G. Wilson Ellis
	Tareas implementadas: hacer testing de implementaciones anteriores(donation entity y product entity con sus respectivos servicios)
*/

/* Project includes */
using Domain.Donations.Entities;
using Domain.Products.Entities;
/* System includes */
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Domain.Orders.Entities;

namespace UnitTests.Domain.Donations.Entities
{
    public class CampaignTests
    {
		//Tests for valid donation instance
        [Fact]
		public void DonationInstance()
		{
			//arrange
			var donationTest = new {
				Id = 1,
				CreationDate = DateTime.Today,
				Status = "A",
				Province = "Provincia", 
				County = "Canton", 
				District= "Distrito", 
				ExactLocation="JuanTalameda",
				Description = "Muy buena comida",
				_products = new List<IProduct>(),
				DonorId = "milen.rodrig.m@gmail.com"
			};
			var donation = new Donation(1, "Provincia", "Canton", "Distrito"
				, "JuanTalameda", "Muy buena comida", "milen.rodrig.m@gmail.com");

			//act and assert
			donation.Should().BeEquivalentTo(donationTest);
		}

		//Tests for empty donation instance
		[Fact]
		public void DonationEmptyInstance()
		{
			//arrange
			var donationTest = new
			{
				Id = 0,
				CreationDate = DateTime.Today,
				Status = "A",
				Province = "",
				County = "",
				District = "",
				ExactLocation = "",
				Description = "",
				_products = new List<IProduct>(),
				DonorId = ""
			};
			var donation = new Donation();

			//act and assert
			donation.Should().BeEquivalentTo(donationTest);
		}

		////Tests for addition of product to donation instance
		[Fact]
		public void AddProductToDonationTest()
        {
			// arrange
			var product = new Product();
			var donation = new Donation();
			// act
			donation.AddProductToDonation(product);
			// assert
			donation.Products.Should().HaveCount(1);
        }

		//Tests for clearance of products of donation instance
		[Fact]
		public void ClearTest()
		{
			// arrange
			var product = new Product();
			var donation = new Donation();
			donation.AddProductToDonation(product);
			// act
			donation.Clear();
			// assert
			donation.Products.Should().HaveCount(0);
		}

		//Tests for modification of donation instance
		[Fact]
		public void ModifyProductTest()
        {
			// arrange
			var old_Product = new Product();
			var new_Product = new Product("producto", "", "", 0, 0, "");
			var product_Test = new
			{
				Name = "producto",
				_orderProducts = new List<OrderProduct>(),
				_restrictions = new List<Restriction>(),
				FoodType = "",
				ProductType = "",
				Quantity = 0,
				Weight = 0,
				ExpirationDate = DateTime.Today,
				Brand = ""
			};
			var donation = new Donation();
			donation.AddProductToDonation(old_Product);
			// act
			donation.ModifyProduct(new_Product, old_Product);
			var p = donation.Products.ElementAt(0);
            // assert
			p.Should().BeEquivalentTo(product_Test);
		}

		////Tests for removal of product from donation instance
		[Fact] 
		public void RemoveProductTest()
        {
			// arrange
			var old_Product = new Product();
			var product_Test = new
			{
				Name = "producto",
				_orderProducts = new List<OrderProduct>(),
				_restrictions = new List<Restriction>(),
				FoodType = "",
				ProductType = "",
				Quantity = 0,
				Weight = 0,
				ExpirationDate = DateTime.Today,
				Brand = ""
			};
			var donation = new Donation();
			donation.AddProductToDonation(old_Product);
			// act
			donation.RemoveProductFromDonation(old_Product);
			// assert
			donation.Products.Should().HaveCount(0);
		}
		
	}
}
