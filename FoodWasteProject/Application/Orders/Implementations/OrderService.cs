using Application.Orders;
using Domain.Core.Repositories;
using Domain.Orders.Entities;
using Domain.Orders.Repositories;
using Domain.Products.Entities;
using Application.Products;
using Domain.Orders.DTOs;
using Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Donations;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("UnitTests")]

namespace Application.Orders.Implementations
{

	internal class OrderService : IOrderService
	{
		private readonly IOrderRepository _OrderRepository;
		private readonly IProductService _productService;
		private readonly IDonationService _donationService;
		private readonly IOrderProductService _orderProductService;
		public OrderService(IOrderRepository OrderRepository)
		{
			_OrderRepository = OrderRepository;
		} 
		public OrderService(IOrderRepository OrderRepository, IProductService productService, IDonationService donationService, IOrderProductService orderProductService)
		{
			_OrderRepository = OrderRepository;
			_productService = productService;
			_donationService = donationService;
			_orderProductService = orderProductService;
		}
		public async Task<int> AddOrderAsync(Order order)
        {
			return await _OrderRepository.AddOrder(order);
        }

		public async Task<IEnumerable<Order>> GetOrderAsync()
		{
			return await _OrderRepository.GetAllAsync();
		}

		public async Task ModifyOrderAsync(Order order)
        {
			await _OrderRepository.ModifyOrder(order);
        }

		public async Task<Order> GetOrderByIdAsync (int id)
        {
			return await _OrderRepository.GetOrderById(id);
        }


		public async Task GetInformationPersonalAsync() {
			await _OrderRepository.GetPersonalInformation();
		}

		public async Task<IList<InformacionDTO>> getInformationPersonalAsync() {
			return await _OrderRepository.getInformationPersonal();
		}
		public async Task<IList<InformacionDTO>> getInformationBusinessAsync()
		{
			return await _OrderRepository.getInformationBusiness();
		}


		public async Task<string> getInformationByEmail(string email, IList<InformacionDTO> _usersInformations ) {
			foreach (var item in _usersInformations) {
				Console.WriteLine("UserItem: " + item.Email + "DonorId: " + email);
				if (item.Email.Equals(email))
				{
					return item.Name + " " + item.LastName;
				}
			}
			return "Desconocido";
        
		}


		public async Task<IList<InformacionDTO>> getAnonInformationAsync() {

			return await _OrderRepository.getAnonInformation();
		}

		public async  Task<int> CreateOrderAsync(Order order, List<Product> products, List<int> selectedQuanitities)
		{
			// Add Order to Order Table
			int orderId= await AddOrderAsync(order);
			// Add Order and Products to OrderProductTable
			int index = 0;
			foreach (var product in products)
			{
				// Product for Update
				Product updatedProduct = new Product(product.Id, product.Name!, product.FoodType!, product.ProductType!,
							product.ExpirationDate, product.Quantity, product.Weight, product.Donation, product.Image!,
							product.Brand!, product.Restrictions.ToList(), product.DonationId);
				// Relationship between Order and Product
				OrderProduct orderProduct = new OrderProduct(order.Id, product.Id, selectedQuanitities[index]);
				// Update total available quantity of the product
				updatedProduct.Quantity = updatedProduct.Quantity - selectedQuanitities[index];
				// Update the Product in DataBase
				await _productService.ModifyProductAsync(updatedProduct);

				await _OrderRepository.AddOrderProduct(orderProduct);
				++index;
			}
			// Call Stored procedure -> SetDonationStatus
			await _donationService.SetDonationStatusAsync(products[0].DonationId);
			return orderId;
		}
		public async Task RejectOrderAsync(Order order)
		{
			// Update Order State
			await ModifyOrderAsync(order);

			// Get Products from Order
			IList<Product> products = await _productService.getProductsByOrderAsync(order.Id);
			
			//  Restore the Total Quantity of the product
			await _orderProductService.UpdateQuantityRejectOrder(order.Id); 
			
			// Call Stored procedure -> SetDonationStatus
			await _donationService.SetDonationStatusAsync(products[0].DonationId);
		}
		public async Task AcceptOrderAsync(Order order)
        {
			// Update Order State
			await ModifyOrderAsync(order);
			// To get DonationId
			IList<Product> products = await _productService.getProductsByOrderAsync(order.Id);
			// Call Stored procedure -> SetDonationStatus
			await _donationService.SetDonationStatusAsync(products[0].DonationId);
		}
		// TODO: Implement service to get DonationId of a Product of an Order
		public async Task CompleteOrderAsync(Order order)
        {
			// Update Order State
			await ModifyOrderAsync(order);
			// To get DonationId
			IList<Product> products = await _productService.getProductsByOrderAsync(order.Id);
			// Call Stored procedure -> SetDonationStatus
			await _donationService.SetDonationStatusAsync(products[0].DonationId);
		}

		public async Task<int> CreateCampaignOrderAsync(Order order, List<int> productsId, List<int> selectedQuanitities)
        {
			// Add Order to Order Table
			int orderId = await AddOrderAsync(order);
			var index = 0;
			// Add Order and Products to OrderProductTable
			foreach (var productId in productsId)
			{
				// Relationship between Order and Product

				OrderProduct orderProduct = new OrderProduct(order.Id, productId, selectedQuanitities[index]);
				await _OrderRepository.AddOrderProduct(orderProduct);
				index++;
			}
			
			return orderId;
		}

    }
}













