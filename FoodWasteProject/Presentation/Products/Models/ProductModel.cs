using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Products;
using Domain.Products.Entities;
namespace Presentation.Products.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FoodType { get; set; }
        public string? ProdType { get; set; }
        public string? Brand { get; set; }
        public DateTime Expiration { get; set; } = DateTime.Today;
        public int Quantity { get; set; }
        public int Goal { get; set; }
        public double Weight { get; set; }
        public List<Restriction> Restrictions;
        public Byte[]? Image { get; set; }

        /*To know if the product has been selected by user to order it*/
        public bool Selected { get; set; } = false;
        public int SelectedQuantity { get; set; } = 0; 
        public int DonationId { get; set; }

        public ProductModel(int id, string name, string foodType, string prodType,
        int quantity, double weight, string brand, DateTime expirationDate, 
        List<Restriction> restrictions, Byte[] image, int donationId) {
            Id = id;
            Name = name;
            FoodType = foodType;
            ProdType = prodType;
            Quantity = quantity;
            Weight = weight;
            Expiration = expirationDate;
            Brand = brand;
            Restrictions = restrictions;
            Image = image;
            DonationId = donationId;
            //imageSrc = $"data:{"png"};base64,{Convert.ToBase64String(Image!)}";
        }

        public ProductModel(string name, string foodType, string prodType,
        int quantity, int goal, double weight) {
            Id = 0;
            Name = name;
            FoodType = foodType;
            ProdType = prodType;
            Quantity = quantity;
            Goal = goal;
            Weight = weight;
            Expiration = DateTime.Today;
            Brand = "";
            Restrictions = null;
            Image = null;
            DonationId = 0;
            //imageSrc = $"data:{"png"};base64,{Convert.ToBase64String(Image!)}";
        }

        public ProductModel(string name, string foodType, string prodType, 
        int quantity, double weight, string brand, DateTime expirationDate) {
            Name = name;
            FoodType = foodType;
            ProdType = prodType;
            Quantity = quantity;
            Weight = weight;
            Expiration = expirationDate;
            Brand = brand;
            Image = null;
            //Creates empty list of restrictions
            Restrictions = new List<Restriction>();
        }
        

        public ProductModel() {
            Id = 0;
            Name = "";
            FoodType = "";
            ProdType = "";
            Quantity = 0;
            Weight = 0.0;
            Expiration = DateTime.Today;
            Brand = "";
            Image = null;
            //Creates empty list of restrictions
            Restrictions = new List<Restriction>();
        }

        public ProductModel(string name, string foodType, string prodType,
        int quantity, double weight, string brand, DateTime expirationDate, 
        List<Restriction> restrictions)
        {
            Name = name;
            FoodType = foodType;
            ProdType = prodType;
            Quantity = quantity;
            Weight = weight;
            Expiration = expirationDate;
            Brand = brand;
            Image = null;
            //Creates empty list of restrictions
            Restrictions = restrictions;
;
        }
    }
}