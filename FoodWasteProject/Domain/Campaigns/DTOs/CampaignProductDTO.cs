/* Campaign module - Asociación Lista y Valiente & Imborrables
 * Collaborators:
 * - Jimena Gdur
 * - Fabian Gonzales
 * - Maeva Murcia
 * 
 * - Summary: Implementation of Campaign class' DTO
 *   Stores all the campaign's information for read only access.
 */

/* Project includes */
using Domain.Campaigns.Entities;
using Domain.Core.ValueObjects;
using Domain.Products.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Campaigns.DTOs
{
    public class CampaignProductDTO
    {
        /**  Attributes **/
        public int Id { get; }
        public int? CampaignId { get; }
        public string? Name { get; }
        public string? FoodType { get; }
        public string? ProductType { get; }
        public int? Quantity { get; }
        public double? Weight { get; }
        public int? Goal { get; }
        public int? Raised { get; }
        public Campaign? Campaign { get; }

        public CampaignProductDTO(int id, int? campaignId, string? name, string? foodType, 
            string? productType, int? quantity, double? weight, int? goal, int? raised, 
            Campaign? campaign)
        {
            Id = id;
            CampaignId = campaignId;
            Name = name;
            FoodType = foodType;
            ProductType = productType;
            Quantity = quantity;
            Weight = weight;
            Goal = goal;
            Raised = raised;
            Campaign = campaign;
        }

        public CampaignProductDTO(int id, int? campaignId, string? name, string? foodType,
            string? productType, int? quantity, double? weight,
            Campaign? campaign)
        {
            Id = id;
            CampaignId = campaignId;
            Name = name;
            FoodType = foodType;
            ProductType = productType;
            Quantity = quantity;
            Weight = weight;
            Campaign = campaign;
        }
    }
}