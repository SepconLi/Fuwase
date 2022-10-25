using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Chats;
using Infrastructure.Chats.Repositories;
using Domain.Messages.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Domain.Messages.Entities;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace IntegrationTests.Chats.Repositories
{
    public class MessageRepositoryTest
    {
       [Fact]
        public async void getAllAsyncTest() {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddDbContext<MessageDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            var app = builder.Build();
            var repository = app.Services.GetRequiredService<IMessageRepository>();

           var result = await repository.GetAllAsync(5);

            result.Should().NotBeNull();

         }

    }
}
