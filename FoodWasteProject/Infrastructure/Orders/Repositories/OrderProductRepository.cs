using Domain.Core.Repositories;
using Domain.Orders.Entities;
using Domain.Orders.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Orders.Repositories
{
    internal class OrderProductRepository : IOrderProductRepository
    {
        private readonly OrderDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public OrderProductRepository(OrderDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task AddOrderProduct(OrderProduct orderProduct)
        {
            _dbContext.OrderProducts.Add(orderProduct);
            await _dbContext.SaveEntitiesAsync();
        }
        public async Task ModifyOrderProduct(OrderProduct orderProduct)
        {
            _dbContext.Entry(orderProduct).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }
        public async Task<IList<OrderProduct>> getOrderProductsByOrderId(int orderId)
        {
            var _orderProducts = await _dbContext.OrderProducts
                .Where(op => op.OrderId == orderId)
                .Select(
                    op => new OrderProduct(op.OrderId, op.Order, op.ProductId, op.Product, op.Quantity )
                ).ToListAsync();
            return _orderProducts;
        }

        public async Task UpdateQuantityRejectOrder(int orderId)
        {
            
            await _dbContext.Database.ExecuteSqlRawAsync($"EXEC UpdateQuantityForRejectOrder @OrderIdp", new SqlParameter("OrderIdp", orderId));

        }
    }

}
