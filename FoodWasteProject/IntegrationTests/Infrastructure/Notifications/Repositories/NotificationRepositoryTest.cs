using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Users.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Notifications.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Infrastructure.Notifications;
using Infrastructure.Notifications.Repositories;
using Domain.Notifications.Repositories;
using Microsoft.AspNetCore.Builder;
using MudBlazor.Services;
using Infrastructure;
using Application;
using Microsoft.Extensions.Configuration;

namespace IntegrationTests.Infrastructure.Notifications.Repositories
{
    public class NotificationRepositoryTest
    {
            [Fact]
            public async void getAllAsyncTest()
            {
                var builder = WebApplication.CreateBuilder();
                builder.Services.AddDbContext<NotificationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")));
                builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
                var app = builder.Build();
                var repository = app.Services.GetRequiredService<INotificationRepository>();

                var result = await repository.GetAllAsync("kimbyCR@gmail.com");

                result.Should().NotBeEmpty();

            }


        [Fact]
        public async Task SaveNotificationAsyncTest()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<INotificationRepository>();

            var notification = new Notification("kimbyCR@gmail.com", "Se ha aceptado tu solicitud de donacion", "requestlist/4", false, DateTime.Now);

            await repository.SaveAsync(notification);

            // Arrange
            var _notifications = await repository.GetAllAsync("kimbyCR@gmail.com");
            var notificationTest = _notifications[_notifications.Length() - 1];
            // Assert
            notificationTest.Should().BeEquivalentTo(notification);
        }
        [Fact]
        public async Task ReadNotificationAsyncTest()
        {
            // Act
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<INotificationRepository>();

            // Arrange

            var _notifications = await repository.GetAllAsync("kimbyCR@gmail.com");
            var notificationTest = _notifications[_notifications.Length() - 1];
            await repository.readNotification(notificationTest);
            // Assert
            notificationTest.ReadNotification.Should().Be(true);
        }



    }
}
