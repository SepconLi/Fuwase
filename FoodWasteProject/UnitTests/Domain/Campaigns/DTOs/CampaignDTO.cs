/* Project includes */
using Domain.Campaigns.DTOs;
/* System includes */
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests.Domain.Campaigns.DTOs
{
    public class CampaignDTOTests
    {
        [Fact]
        public void CampaignDTOInstance()
        {
            // arrange
            var campaign = new CampaignDTO(5, "email", "name", "description",
            DateTime.Today, DateTime.Today, 70, 30, 10, 'O', "province", "county",
            "district", "location");
            // act
            var obj = new {
                Id = 5,
                CreatorEmail = "email",
                Name = "name",
                Description = "description",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today,
                Goal = 70,
                Raised = 30,
                Delivered = 10,
                Province = "province",
                County = "county",
                District = "district",
                ExactLocation = "location",
                Type = 'O',
                Status = 'A'
            };
            // assert
            campaign.Should().BeEquivalentTo(obj);
        }
    }
}
