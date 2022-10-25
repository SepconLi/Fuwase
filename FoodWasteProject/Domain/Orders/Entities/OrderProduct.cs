/*
+-Los Imborrables
+
+Collaborators:
+-Andres
+-Gilbert
+-Fabian
+-Maeva
+
+-Summary: Component that makes the OrderProduct
+*/

using Domain.Core.Entities;
using Domain.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.Entities
{
    /*Relationship between products and Orders*/
    public class OrderProduct {

        /* Order instance and Order Key*/
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        /* Product instance and Product Keys */
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        /* Attribute of relation */
        public int Quantity { get; set; }

        public OrderProduct()
        {
            OrderId = 0;
            Order = null;
            Product = null;
            ProductId = 0;
            Quantity = 0;
        }

        public OrderProduct(int orderId, Order? order, int productId, Product? product, int quantity)
        {
            OrderId = orderId;
            Order = order;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
        }

        public OrderProduct(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
