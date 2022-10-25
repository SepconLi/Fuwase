/* Project includes */
using Domain.Campaigns.DTOs;
using Domain.Campaigns.Entities;
/* System includes */
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests.Domain.Campaigns.DTOs
{
    public class CampaignProductDTOTests
    {
        [Fact]
        public void CampaignProductDTOInstance()
        {
            // arrange

            var campaign = new Campaign("CreatorEmail", "Name", "Description",
                DateTime.Today, DateTime.Today, 40, 20, 40, 'O', "Provincia",
                "Canton", "Distrito", "ExactLocation");


            var campaignProduct = new CampaignProductDTO( 1, 1,"name", "foodType",
            "productType", 1, 1, 1, 1,campaign);
            // act
            var campaignProductDTOTest = new {
            Id = 1,
            CampaignId = 1,
            Name = "name",
            FoodType = "foodType",
            ProductType = "productType",
            Quantity = 1,
            Weight = 1,
            Goal = 1,
            Raised = 1,
            campaignTest = campaign,
            };
            // assert
            campaignProduct.Name.Should().Be(campaignProductDTOTest.Name);
            campaignProduct.FoodType.Should().Be(campaignProductDTOTest.FoodType);
            campaignProduct.ProductType.Should().Be(campaignProductDTOTest.ProductType);
            campaignProduct.Quantity.Should().Be(campaignProductDTOTest.Quantity);
            campaignProduct.Weight.Should().Be(campaignProductDTOTest.Weight);
            campaignProduct.Goal.Should().Be(campaignProductDTOTest.Goal);
            campaignProduct.Raised.Should().Be(campaignProductDTOTest.Raised);
            campaignProduct.Campaign.Should().Be(campaignProductDTOTest.campaignTest);
        }

        [Fact]
        public void CampaignProductDTO2Instance()
        {
            // arrange

            var campaign = new Campaign("CreatorEmail", "Name", "Description",
                DateTime.Today, DateTime.Today, 40, 20, 40, 'O', "Provincia",
                "Canton", "Distrito", "ExactLocation");


            var campaignProduct = new CampaignProductDTO(1, 1, "name", "foodType",
            "productType", 1, 1, campaign);
            // act
            var campaignProductDTOTest = new
            {
                Id = 1,
                CampaignId = 1,
                Name = "name",
                FoodType = "foodType",
                ProductType = "productType",
                Quantity = 1,
                Weight = 1,
                campaignTest = campaign,
            };
            // assert
            campaignProduct.Name.Should().Be(campaignProductDTOTest.Name);
            campaignProduct.FoodType.Should().Be(campaignProductDTOTest.FoodType);
            campaignProduct.ProductType.Should().Be(campaignProductDTOTest.ProductType);
            campaignProduct.Quantity.Should().Be(campaignProductDTOTest.Quantity);
            campaignProduct.Weight.Should().Be(campaignProductDTOTest.Weight);
            campaignProduct.Campaign.Should().Be(campaignProductDTOTest.campaignTest);
        }
    }
}
