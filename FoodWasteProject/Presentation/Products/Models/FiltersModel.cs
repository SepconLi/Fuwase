using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Products;
using Domain.Products.Entities;

namespace Presentation.Products.Models
{
    public class FiltersModel
    {
        public string? Name { get; set; }
        public string? FoodType { get; set; }
        public string? ProdType { get; set; }
        public string? Brand { get; set; }
        public DateTime Expiration { get; set; } = DateTime.Today;
        public double Weight { get; set; }
        public List<String> Restrictions { get; set; }

        public FiltersModel()
        {
            Name = "";
            FoodType = "";
            ProdType = "";
            Weight = 0.0;
            Brand = "";
            Restrictions = new List<string>();
        }

        public FiltersModel(string name, string foodType, string prodType, double weight, string brand, DateTime expirationDate, List<String> restrictions)
        {
            Name = name;
            FoodType = foodType;
            ProdType = prodType;
            Weight = weight;
            Expiration = expirationDate;
            Brand = brand;
            Restrictions = restrictions;
        }
    }
}