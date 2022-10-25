/*
+-Los Macacos
+
+Collaborators:
+-Josher Ramirez
+-Sirlany Mora
+-Aaron Campos
+-Estefany Ramirez
+-David Rojas
+
+-Summary: Component that makes the donation order.
+*/


/* Project includes */
using Domain.Core.Entities;
using Domain.Core.Exceptions;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Products.Entities;
/* System  includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.Entities
{/**  Attributes **/

    // Basic attributes
    public class Order : AggregateRoot
    {
        // Basic attributes
        public string? OrderStatus { get; set; }

        public string DonorId { get; set; }

        public string RecipientId { get; set; }

        // Other attributes

        private readonly List<OrderProduct> _orderProducts;
        public IReadOnlyCollection<OrderProduct> OrderProducts => _orderProducts.AsReadOnly();

        /**  Methods **/

        // Basic constructor for Orders
        public Order()
        {
            OrderStatus = "P";
        }

        public Order(string? status, string donor, string recipient)
        {
            OrderStatus = status;
            DonorId = donor;
            RecipientId = recipient;
            _orderProducts = new List<OrderProduct>();
        }
        public Order(int id, string? status, string donor, string recipient)
        {
            Id = id;
            OrderStatus = status;
            DonorId = donor;
            RecipientId = recipient;
            _orderProducts = new List<OrderProduct>();
        }

        public Dictionary<string, string> statusDictionary = new Dictionary<string, string>()
        {
            {"P","Pendiente"},
            {"A","Aceptada"},
            {"F","Finalizada"},
            {"R","Rechazada"},
            {"D","Aceptada"},
            {"d","Aceptada"},
            {"B","Aceptada"},
            {"b","Aceptada"}
        };



    }
}
