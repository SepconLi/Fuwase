using Domain.Core.Repositories;
using Domain.Orders.Entities;
using Domain.Orders.Repositories;
using Domain.Orders.DTOs;
using Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("UnitTests")]

namespace Infrastructure.Orders.Repositories
{
    internal class OrderRepository : IOrderRepository
    {

        private readonly OrderDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public OrderRepository(OrderDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<int> AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveEntitiesAsync();
            return order.Id;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.Select(t => new Order(t.Id, t.OrderStatus, t.DonorId, t.RecipientId)).ToListAsync();
        }

        public async Task ModifyOrder(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _dbContext.Orders.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task SaveAsync(Order order)
        {
            _dbContext.Add(order);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task AddOrderProduct(OrderProduct orderProduct)
        {
            _dbContext.OrderProducts.Add(orderProduct);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task GetPersonalInformation() {
            Console.WriteLine("Hola");
            var query = _dbContext.PersonalUsers.Join(_dbContext.Donations, personalUser => personalUser.Email,
                donation => donation.DonorId,
                (personalUser, donation) => new
                {
                    Name = personalUser.Name,
                    LastName = personalUser.LastName,
                    IdDonor = donation.DonorId
                }).ToList();
            foreach (var item in query) {
                Console.WriteLine("{0} {1} {2} Email ID: {3}",item.Name,item.LastName,item.IdDonor);
            }
        }
        
        public async Task<IList<InformacionDTO>> getInformationPersonal() {
            return await _dbContext.PersonalUsers.Select(t => new InformacionDTO(t.Email, t.Name ,t.LastName)).ToListAsync();
            
        }

        public async Task<IList<InformacionDTO>> getInformationBusiness() {
            return await _dbContext.BusinessUsers.Select(t=> new InformacionDTO (t.Email,t.Business_Name)).ToListAsync();
        }
        public async Task<IList<InformacionDTO>> getAnonInformation() { 
            return await _dbContext.Users.Select(t=> new InformacionDTO (t.Email,t.Anom_Preference,t.UserName)).ToListAsync();
        }

    }
}











