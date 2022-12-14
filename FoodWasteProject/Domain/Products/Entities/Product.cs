/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Implementation of Product class
 *   Stores all the product's information.
 */

/* Project includes */
using Domain.Core.Entities;
using Domain.Core.Exceptions;
using Domain.Core.ValueObjects;
using Domain.Donations.Entities;
using Domain.Orders.Entities;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products.Entities
{
    public class Product : IProduct
    {
        /**  Attributes **/

        // Basic attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public int DonationId { get; set; }
        public string FoodType { get; set; }
        public string ProductType { get; set; }
        public string? Brand { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public byte[]? Image { get; set; }

        // Other attributes
        public Donation? Donation { get; private set; }
        public int? OrderId { get; set; } // Remove later
        private readonly List<OrderProduct> _orderProducts;
        public IReadOnlyCollection<OrderProduct> OrderProducts => _orderProducts.AsReadOnly();

        private readonly List<Restriction> _restrictions;
        public IReadOnlyCollection<Restriction> Restrictions
            => _restrictions.AsReadOnly();

        /**  Methods **/

        // Basic constructor for Product
        public Product(string name, string foodType, string prodType,
            int quantity, double weight, string brand)
        {
            Id = 0;
            Donation = null;
            OrderId = null;
            _orderProducts = new List<OrderProduct>();
            _restrictions = new List<Restriction>();
            Name = name;
            FoodType = foodType;
            ProductType = prodType;
            Quantity = quantity;
            Weight = weight;
            ExpirationDate = DateTime.Today;
            Image = null;
            Brand = brand;
        }

        // More complex constructor for Product
        public Product(int id, string name, string foodType, string prodType, 
            DateTime expirationDate, int quantity, double weight, 
            Donation? donation, byte[] image, string brand, 
            List<Restriction> restrictions, int donationId)
        {
            Id = id;
            Name = name;
            FoodType = foodType;
            ProductType = prodType;
            ExpirationDate = expirationDate;
            Quantity = quantity;
            Weight = weight;
            Donation = donation;
            Image = image;
            Brand = brand;
            _restrictions = restrictions.ToList();
            DonationId = donationId;
            OrderId = null;
            _orderProducts = new List<OrderProduct>();
        }

        // Constructor for tests
        public Product(string name, string foodType, string prodType,
            DateTime expirationDate, int quantity, double weight,
            Donation? donation, byte[] image, string brand,
            List<Restriction> restrictions, int donationId)
        {
            Id = 0;
            Name = name;
            FoodType = foodType;
            ProductType = prodType;
            ExpirationDate = expirationDate;
            Quantity = quantity;
            Weight = weight;
            Donation = donation;
            Image = image;
            Brand = brand;
            _restrictions = restrictions.ToList();
            DonationId = donationId;
            OrderId = null;
            _orderProducts = new List<OrderProduct>();
        }

        public Product(string name, string foodType, string prodType,int? quantity, double? weight)
        {
            Name = name;
            FoodType = foodType;
            ProductType = prodType;
            Quantity = (int)quantity;
            Weight = (double)weight;
        }

        // Empty constructor for EFCore
        public Product()
        {
            Id = 0;
            Name = "";
            FoodType = "";
            ProductType = "";
            Brand = "";
            Donation = null!;
            _orderProducts = new List<OrderProduct>();
            _restrictions = new List<Restriction>();
            Image = null;
            OrderId = null;
        }

        // Assigns the donation to which the product belongs
        public void AssignDonation(Donation? donation)
        {
            Donation = donation;
            if (Donation != null)
            {
                DonationId = donation.Id;
            }

        }

        // Assign order to its instance
        public void AddOrderProductToProduct(OrderProduct orderProduct)
        {
            if (_orderProducts.Exists(op => op == orderProduct))
                throw new DomainException
                    ("Product is already in the order.");
            if (_orderProducts.Exists(op => op.OrderId == orderProduct.OrderId)
                && _orderProducts.Exists(op => op.ProductId == orderProduct.ProductId))
                throw new DomainException
                    ("An OrderProduct with that name is " +
                        "already registered in the donation.");

            _orderProducts.Add(orderProduct);
        }


        // Resets the restrictions values
        public void ClearRestrictions()
        {
            _restrictions.Clear();
        }

        // Adds restrictions to a product
        public void AddRestrictionToProduct(Restriction restriction)
        {
            _restrictions.Add(restriction);
            restriction.AssignProduct(this);
        }

        // Deletes restrictions from a product
        public void RemoveRestrictionFromProduct(Restriction restriction)
        {
            if (_restrictions.Exists(p => p == restriction))
            {
                _restrictions.Remove(restriction);
                restriction.AssignProduct(null);
            }
        }
    }
}