using Infrastructure.Orders.Repositories;
using Infrastructure.Orders;
using Domain.Orders.Entities;
using FluentAssertions;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Application.Donations.Implementations;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Donations.DTOs;
using Domain.Donations.Entities;
using Domain.Donations.Repositories;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Builder;
using Infrastructure.Orders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Orders.Repositories;
using Infrastructure.Orders.Repositories;
using Domain.Orders.Entities;
using Infrastructure;
using Microsoft.Extensions.Configuration;

namespace IntegrationTests.Infrastructure.Orders.Repositories
{
    public class OrderRepositoryTests
    {
        [Fact]
        public async void addOrderIsNotNullTest()
        {
            var builder = WebApplication.CreateBuilder();
            //builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));
            builder.Services.AddScoped < IOrderRepository, OrderRepository>();
            var app = builder.Build();
            var repository = app.Services.GetRequiredService<IOrderRepository>();

            Order newOrder = new Order("P", "gilbert@ucr.ac.cr", "maeva@ucr.ac.cr");

            var orderId = await repository.AddOrder(newOrder);

            var result = await repository.GetOrderById(orderId);

            result.Should().NotBeNull();

        }

        [Fact]
        public async void addOrderCorrectAttributesTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));
            //builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            var app = builder.Build();
            var repository = app.Services.GetRequiredService<IOrderRepository>();

            Order newOrder = new Order("P", "gilbert@ucr.ac.cr", "maeva@ucr.ac.cr");

            var orderId = await repository.AddOrder(newOrder);

            var result = await repository.GetOrderById(orderId);

            result.Id.Should().Be(orderId);
            result.OrderStatus.Should().Be("P");

            result.DonorId.Should().Be("gilbert@ucr.ac.cr");
            result.RecipientId.Should().Be("maeva@ucr.ac.cr");
        }
        [Fact]
        public async void GetOrderByIdTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            var app = builder.Build();
            var repository = app.Services.GetRequiredService<IOrderRepository>();

            var result = await repository.GetOrderById(99);

            result.Id.Should().Be(99);
            result.OrderStatus.Should().Be("P");

            result.DonorId.Should().Be("gilbert@ucr.ac.cr");
            result.RecipientId.Should().Be("maeva@ucr.ac.cr");
        }
        [Fact]
        public async void getInformationPersonalReturnsValidList()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            var app = builder.Build();
            var repo = app.Services.GetRequiredService<IOrderRepository>();

            var result = await repo.getInformationPersonal();
            result.Should().NotBeNull();
        }
        [Fact]
        public async void getAnonInformationReturnsValidList()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            var app = builder.Build();
            var repo = app.Services.GetRequiredService<IOrderRepository>();

            var result = await repo.getAnonInformation();
            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetAllAsyncTest()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            var app = builder.Build();
            var repo = app.Services.GetRequiredService<IOrderRepository>();

            var result = await repo.GetAllAsync();
            Assert.NotNull(result);
            result.Should().NotBeNull();
            Order _order = new Order("P","donador","beneficiario");

            // Act and assert
            int resultID = await repo.AddOrder(_order);
            resultID.Should().BeGreaterThanOrEqualTo(0);
        }
        
    }
}
