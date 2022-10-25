/*
	ALV-DO-4.1 Create a donation campaign, ALV-DO-4.5 Donate in a campaign,  ALV-DO-4.3 See progress of a campaign
	Jimena Gdur Vargas
	Testing for Campaign Entity
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
    public class CampaignTests
    {
        //Tests for valid campaigns instance
        [Fact]
        public void CampaignInstance()
        {
            // arrange
            var campaignTest = new
            {
                CreatorEmail = "CreatorEmail",
                Name = "Name",
                Description = "Description",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today,
                Goal = 40,
                Raised = 20,
                Delivered = 40,
                Province = "Provincia",
                County = "Canton",
                District = "Distrito",
                ExactLocation = "ExactLocation",
                Type = 'O',
                Status = 'A',
                _products = new List<CampaignProduct>()
            };

            var campaign = new Campaign("CreatorEmail", "Name", "Description",
                DateTime.Today, DateTime.Today, 40, 20, 40, 'O', "Provincia",
                "Canton", "Distrito", "ExactLocation");

            //act and assert
            campaign.Should().BeEquivalentTo(campaignTest);
        }

        //Tests for empty campaign instance
        [Fact]
        public void CampaignEmptyInstance()
        {
            //arrange
            var campaignTest = new
            {
                CreatorEmail = "",
                Name = "",
                Description = "",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today,
                Goal = 0,
                Raised = 0,
                Delivered = 0,
                Province = "",
                County = "",
                District = "",
                ExactLocation = "",
                Type = 'O',
                Status = 'A',
                _products = new List<CampaignProduct>()
            };
            var campaign = new Campaign();

            //act and assert
            campaign.Should().BeEquivalentTo(campaignTest);
        }

        // Tests for addition of product to campaign instance
        [Fact]
        public void AddProductToCampaignTest()
        {
            // arrange
            var product = new CampaignProduct();
            var campaign = new Campaign();
            // act
            campaign.AddProductToCampaign(product);
            // assert
            campaign.Products.Should().HaveCount(1);
        }

        // Tests for clearance of products of campaign instance
        [Fact]
        public void ClearTest()
        {
            // arrange
            var product = new CampaignProduct();
            var campaign = new Campaign();
            campaign.AddProductToCampaign(product);
            // act
            campaign.Clear();
            // assert
            campaign.Products.Should().HaveCount(0);
        }

        // Tests for modification of campaign instance
        [Fact]
        public void ModifyProductTest()
        {
            // arrange
            var old_Product = new CampaignProduct();
            var new_Product = new CampaignProduct("producto", "", "", 0, 0.0, 0);
            var product_Test = new
            {
                Id = 0,
                CampaignId = 0,
                Name = "producto",
                FoodType = "",
                ProductType = "",
                Quantity = 0,
                Weight = 0,
                Goal = 0,
                Raised = 0
            };
            var campaign = new Campaign();
            campaign.AddProductToCampaign(old_Product);
            // act
            campaign.ModifyProduct(new_Product, old_Product);
            var p = campaign.Products.ElementAt(0);
            // assert
            p.Should().BeEquivalentTo(product_Test);
        }

        // Tests for removal of product from campaign instance
        [Fact]
        public void RemoveProductTest()
        {
            // arrange
            var old_Product = new CampaignProduct();
            var product_Test = new
            {
                Id = 0,
                CampaignId = 0,
                Name = "producto",
                FoodType = "",
                ProductType = "",
                Quantity = 0,
                Weight = 0,
                Goal = 0,
                Raised = 0
            };
            var campaign = new Campaign();
            campaign.AddProductToCampaign(old_Product);
            // act
            campaign.RemoveProductFromCampaign(old_Product);
            // assert
            campaign.Products.Should().HaveCount(0);
        }

    }
}
