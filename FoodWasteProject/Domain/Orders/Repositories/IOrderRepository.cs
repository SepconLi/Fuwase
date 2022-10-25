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
+-Summary: Component that defines the services.
+*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Orders.Entities;
using Domain.Core.Repositories;
using Domain.Orders.DTOs;
using Domain.Users.Entities;

namespace Domain.Orders.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<int> AddOrder(Order order);
        Task<IEnumerable<Order>> GetAllAsync();

        Task ModifyOrder(Order order);

        Task<Order> GetOrderById (int id);

        Task SaveAsync (Order order);

        Task GetPersonalInformation();

        Task<IList<InformacionDTO>> getInformationPersonal();
        Task<IList<InformacionDTO>> getInformationBusiness();
        // Add relationship between Order and Product
        Task AddOrderProduct (OrderProduct orderProduct);
        Task<IList<InformacionDTO>> getAnonInformation();
    }
}
