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
+-Summary: Component that makes the service interface.
+*/
using Domain.Orders.Entities;
using Domain.Products.Entities;
using Domain.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders
{
    public interface IOrderService
    {
        Task<int> AddOrderAsync(Order order);

        Task ModifyOrderAsync(Order order);

        Task<IEnumerable<Order>> GetOrderAsync();
        
        Task<Order> GetOrderByIdAsync (int id);

        // Task AddProductToOrderAsync(Order order, Product product);

        Task GetInformationPersonalAsync();
        Task<IList<InformacionDTO>> getInformationBusinessAsync();
        Task<IList<InformacionDTO>> getInformationPersonalAsync();
        Task<string> getInformationByEmail(string email, IList<InformacionDTO> _usersInformations);
        Task<IList<InformacionDTO>> getAnonInformationAsync();


        // Order.Status = "P" -> Pending
        Task<int> CreateOrderAsync(Order order, List<Product> products, List<int> quantity);

        // For order “Rejected” y “Not Finalized”(Delivery not succesful)
        // For Rejected -> Order.Status = “R”
        // For Not Finalized -> Order.Status = “R”
        Task RejectOrderAsync(Order order);
        
        // Order.Status = “A” -> Accepted
        Task AcceptOrderAsync(Order order);
        
        // Order.Status = “F” -> Finalized / Completed
        Task CompleteOrderAsync(Order order);

        Task<int> CreateCampaignOrderAsync(Order order, List<int> productsId, List<int> selectedQuanitities);
    }
}
