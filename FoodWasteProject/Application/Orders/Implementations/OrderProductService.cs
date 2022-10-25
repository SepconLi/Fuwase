using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Orders;
using Application.Products;
using Domain.Core.Repositories;
using Domain.Orders.Entities;
using Domain.Orders.Repositories;
using Domain.Products.Entities;

namespace Application.Orders.Implementations
{
    public class OrderProductService : IOrderProductService
    {
		private readonly IOrderProductRepository _OrderProductRepository;
		private readonly IProductService _productService;
		public OrderProductService(IOrderProductRepository OrderProductRepository)
		{
			_OrderProductRepository = OrderProductRepository;
		}
		public OrderProductService(IOrderProductRepository OrderProductRepository, IProductService productService)
		{
			_OrderProductRepository = OrderProductRepository;
			_productService = productService;
		}
		public async Task AddOrderProduct(OrderProduct orderProduct)
        {
             await _OrderProductRepository.AddOrderProduct(orderProduct);
        }

        public async Task<IList<OrderProduct>> getOrderProductsByOrderId(int orderId)
        {
            return await _OrderProductRepository.getOrderProductsByOrderId(orderId);
        }
        public async Task ModifyOrderProduct(OrderProduct orderProduct)
        {
            await _OrderProductRepository.ModifyOrderProduct(orderProduct);
        }

        public async Task UpdateQuantityRejectOrder( int orderId)
        {
            await _OrderProductRepository.UpdateQuantityRejectOrder(orderId);
        }
    }
}


