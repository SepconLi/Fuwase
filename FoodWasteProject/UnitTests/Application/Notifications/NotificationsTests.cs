using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Notifications.Repositories;
using Domain.Notifications.Entities;
using Application.Notifications.Implementation;
using Moq;
using FluentAssertions;



namespace UnitTests.Application.Notifications
{
    public class NotificationsTests
    {


        [Fact]
        public async Task GetAllAsyncTest()
        {
            var mockNotificationRepository = new Mock<INotificationRepository>();

            IList<Notification> notifications = new List<Notification>();
            var notification1 = new Notification();
            notifications.Add(notification1);
            var notification2 = new Notification();
            notifications.Add(notification2);

            mockNotificationRepository.Setup(t => t.GetAllAsync("campos1024a@gmail.com")).ReturnsAsync(notifications);
            var notificationService = new NotificationService(mockNotificationRepository.Object);
            //act 
            var listNotifications = await notificationService.GetNotificationByEmailAsync("campos1024a@gmail.com");
            //assert 
            listNotifications.Should().NotBeEmpty();

        }
        [Fact] 
        public async void AddNotificationTest()
        {
            // arrange

            //To test the funcionality it is needed to create a personal user, because user is an abstract class
            var notification = new Notification();

            var mockNoticationRepository = new Mock<INotificationRepository>();
            mockNoticationRepository.Setup(repo => repo.SaveAsync(notification));
            var userService = new NotificationService(mockNoticationRepository.Object);

            // act
            await userService.addNotification(notification);
            // assert
            mockNoticationRepository.Verify(repo => repo.SaveAsync(notification), Times.Once);

        }
        [Fact]
        public async void readNotificationTest()
        {
            // arrange

            //To test the funcionality it is needed to create a personal user, because user is an abstract class
            var notification = new Notification("campos1024a@gmail.com", "Notificacion de prueba", "requestList/4", true , DateTime.Now);
            var mockNoticationRepository = new Mock<INotificationRepository>();
            mockNoticationRepository.Setup(repo => repo.readNotification(notification));
            var userService = new NotificationService(mockNoticationRepository.Object);

            // act
            await userService.readNotificationAsync(notification);
            // assert
            notification.ReadNotification.Should().Be(true);

        }
    }
}
