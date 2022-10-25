using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Campaigns.Models
{
    public class CampaignProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FoodType { get; set; }
        public string? ProductType { get; set; }
        public int Quantity { get; set; }
        public double? Weight { get; set; }
        public Byte[]? Image { get; set; }

        /*To know if the product has been selected by user to order it*/
        public bool Selected { get; set; } = false;
        public int SelectedQuantity { get; set; } = 0;
        public int CampaignId { get; set; }

        public CampaignProductModel(int id, string name, string foodType, string prodType,
        int quantity, double weight, int campaignId)
        {
            Id = id;
            Name = name;
            FoodType = foodType;
            ProductType = prodType;
            Quantity = quantity;
            Weight = weight;
            CampaignId = campaignId;
        }

        public CampaignProductModel(string name, string foodType, string prodType,int quantity, double? weight, Byte[] image)
        {
            Name = name;
            FoodType = foodType;
            ProductType = prodType;
            Quantity = quantity;
            Weight = weight;
            Image = image;
        }


        public CampaignProductModel()
        {
            Id = 0;
            Name = "";
            FoodType = "";
            ProductType = "";
            Quantity = 0;
            Weight = 0.0;
            Image = null;
        }
    }
}
