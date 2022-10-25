using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Orders.Entities;

namespace Application.Orders
{
    public interface IOrderProductService
    {
        // Add relationship between Order and Product
        Task AddOrderProduct(OrderProduct orderProduct);
        // Modify relationship between Order and Product
        Task ModifyOrderProduct(OrderProduct orderProduct);
        // Get relationships between products and an Order
        Task<IList<OrderProduct>> getOrderProductsByOrderId(int orderId);
        Task UpdateQuantityRejectOrder(int orderId);
    }
}
