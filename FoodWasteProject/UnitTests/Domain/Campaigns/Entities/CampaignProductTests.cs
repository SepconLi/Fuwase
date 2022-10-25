/*
	ALV-DO-4.1 Create a donation campaign, ALV-DO-4.5 Donate in a campaign,  ALV-DO-4.3 See progress of a campaign, 
    LI-BE-6.1 List of active campaigns, LI-BE-6.2 Full page of a donation campaign, LI-BE-6.3 Receive products from an active donation campaign page,

	Maeva Murcia Melendez
	Testing for CampaignProduct Entity
*/

/* Project includes */
using Domain.Campaigns.Entities;

/* System includes */
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Domain.Campaigns.Entities
{
    public class CampaignProductTests
    {
        //Tests for valid campaigns instance
        [Fact]
        public void CampaignProductInstance()
        {
            // arrange
            var campaignProductTest = new
            {
                CampaignId = 0,
                Name = "Name",
                FoodType = "FoodType",
                ProductType = "ProductType",
                Quantity = 0,
                Weight = 0,
                Goal = 0,
                Raised = 0,
            };

            var campaignProduct = new CampaignProduct("Name", "FoodType", "ProductType",
                0, 0, 0);

            //act and assert
            campaignProduct.Name.Should().Be(campaignProductTest.Name);
            campaignProduct.FoodType.Should().Be(campaignProductTest.FoodType);
            campaignProduct.ProductType.Should().Be(campaignProductTest.ProductType);
            campaignProduct.Quantity.Should().Be(campaignProductTest.Quantity);
            campaignProduct.Weight.Should().Be(campaignProductTest.Weight);
            campaignProduct.Goal.Should().Be(campaignProductTest.Goal);
            campaignProduct.Raised.Should().Be(campaignProductTest.Raised);
            campaignProduct.Campaign.Should().Be(null);
        }

        //Tests for valid campaigns instance
        [Fact]
        public void CampaignProductWithOutCampaignInstance()
        {
            // arrange
            var campaignProductTest = new
            {
                Id = 1,
                CampaignId = 1,
                Name = "Name",
                FoodType = "FoodType",
                ProductType = "ProductType",
                Quantity = 0,
                Weight = 0,
            };

            var campaignProduct = new CampaignProduct(1, 1,"Name", "FoodType", "ProductType",0, 0);

            //act and assert
            campaignProduct.Should().BeEquivalentTo(campaignProductTest);

        }

        //Tests for empty campaign instance
        [Fact]
        public void CampaignProductEmptyInstance()
        {
            //arrange
            var campaignProductTest = new
            {
                CampaignId = 0,
                Name = "",
                FoodType = "",
                ProductType = "",
                Quantity = -1,
                Weight = -1,
                Goal = -1,
                Raised = -1,
            };
            var campaignProduct = new CampaignProduct();

            //act and assert
            campaignProduct.Name.Should().Be(campaignProductTest.Name);
            campaignProduct.FoodType.Should().Be(campaignProductTest.FoodType);
            campaignProduct.ProductType.Should().Be(campaignProductTest.ProductType);
            campaignProduct.Quantity.Should().Be(campaignProductTest.Quantity);
            campaignProduct.Weight.Should().Be(campaignProductTest.Weight);
            campaignProduct.Goal.Should().Be(campaignProductTest.Goal);
            campaignProduct.Raised.Should().Be(campaignProductTest.Raised);
            campaignProduct.Campaign.Should().Be(null);
        }

        // Tests for assigning campaign to a campaignProducts. 
        [Fact]
        public void AssignCampaignTest()
        {
            // arrange
            var new_Product = new CampaignProduct("producto", "", "", 0, 0.0, 0);

            var campaign = new Campaign("CreatorEmail", "Name", "Description",
                DateTime.Today, DateTime.Today, 40, 20, 40, 'O', "Provincia",
                "Canton", "Distrito", "ExactLocation");

            // act
            new_Product.AssignCampaign(campaign);
            var p = new_Product.CampaignId;
            // assert
            p.Should().Be(campaign.Id);
        }

    }
}