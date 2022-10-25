using Domain.Orders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.Repositories
{
    public interface IOrderProductRepository
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
