/* Campaign module - Asociación Lista y Valiente & Imborrables
 * Collaborators:
 * - Jimena Gdur
 * - Fabian Gonzales
 * - Maeva Murcia
 * - Summary: Implementation of CampaignProduct class
 *   Stores all a campaign's possible products.
 */

/* Project includes */
using Domain.Core.Entities;
using Domain.Core.Exceptions;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Campaigns.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Campaigns.Entities
{
    public class CampaignProduct
    {
        /**  Attributes **/

        // Basic attributes
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public string? Name { get; set; }
        public string? FoodType { get; set; }
        public string? ProductType { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public int? Goal { get; set; }
        public int? Raised { get; set; }
        public Campaign? Campaign { get; set; }

        /**  Methods **/

        // Basic constructor for CampaignProduct
        public CampaignProduct(string? name, string? foodType,
            string? productType, int goal, double weight, int raised)
        {
            CampaignId = 0;
            Name = name;
            FoodType = foodType;
            ProductType = productType;
            Quantity = 0;
            Weight = weight;
            Goal = goal;
            Raised = raised;
            Campaign = null;
        }

        public CampaignProduct(int campaignProductId, int campaignId, string? name, string? foodType, string? productType, int? quantity, double? weight)
        {
            Id = campaignProductId;
            CampaignId = campaignId;
            Name = name;
            FoodType = foodType;
            ProductType = productType;
            Quantity = quantity;
            Weight = weight;
        }

        // Empty constructor for EFCore
        public CampaignProduct()
        {
            CampaignId = 0;
            Name = "";
            FoodType = "";
            ProductType = "";
            Quantity = -1;
            Weight = -1;
            Goal = -1;
            Raised = -1;
            Campaign = null;
        }

        // Assigns the campaign to which the product belongs
        public void AssignCampaign(Campaign campaign)
        {
            Campaign = campaign;
            CampaignId = campaign.Id;
        }
    }
}
