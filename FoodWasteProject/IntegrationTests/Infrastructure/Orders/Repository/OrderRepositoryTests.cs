using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

using Xunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Infrastructure.Orders.Repositories;
using Domain.Orders.Repositories;
using Infrastructure;
using Domain.Orders.Entities;
using Infrastructure.Orders;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Infrastructure.Orders.Repository
{
    public class OrderRepositoryTests
    {
        [Fact]
        public async void addOrderTest()
        { 
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            var app = builder.Build();
            var repo = app.Services.GetRequiredService<IOrderRepository>();

            Order orden = new Order("P", "donador", "beneficiario");

            var result = await repo.AddOrder(orden);

            result.Should().BeGreaterThanOrEqualTo(0);

        }
        [Fact]
        public async void getBusinessInfoReturnsValidList()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            var app = builder.Build();
            var repo = app.Services.GetRequiredService<IOrderRepository>();

            var result = await repo.getInformationBusiness();
            result.Should().NotBeNull();
        }
    }
}
