

/* Project includes */
using Domain.Notifications.Entities;

/* System includes */
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Domain.Notifications.Entities;

namespace UnitTests.Domain.Notifications.Entities
{
    public class NotificationTests
    {
		//Tests for valid Notification instance
        [Fact]
		public void NotificationInstance()
		{
			//arrange
			var notification = new Notification("sirlany.morag@gmail.com", "La solicitud de donacion fue enviada", "/requestDetails", false, DateTime.Now);

			var notificationTest = new
				{
				Email = "sirlany.morag@gmail.com",
				NotificationText = "La solicitud de donacion fue enviada",
				Link = "/requestDetails",
				ReadNotification =  false,
				TimeNotification = notification.TimeNotification
				};
			

			//act and assert
			notification.Should().BeEquivalentTo(notificationTest);
		}

		//Tests for empty donation instance
		[Fact]
		public void NotificationEmptyInstance()
		{
			//arrange
			var notification = new Notification();

			var notificationTest = new
			{
				Email = "",
				NotificationText = "",
				Link = "",
				ReadNotification = false,
				TimeNotification = notification.TimeNotification
			};


		}

		[Fact]
		public void NotificationInstanceWithId()
		{
			//arrange
			var notification = new Notification(1, "sirlany.morag@gmail.com", "La solicitud de donacion fue enviada", "/requestDetails", false, DateTime.Now);

			var notificationTest = new
			{	
				Id = 1,
				Email = "sirlany.morag@gmail.com",
				NotificationText = "La solicitud de donacion fue enviada",
				Link = "/requestDetails",
				ReadNotification = false,
				TimeNotification = notification.TimeNotification
			};


			//act and assert
			notification.Should().BeEquivalentTo(notificationTest);
		}

		[Fact]
		public void NotificationtEmptyEmail()
		{
			Notification notification = new Notification();
			notification.Email.Should().Be("");
		}

		[Fact]
		public void NotificationtEmptyNotificationText()
		{
			Notification notification = new Notification();
			notification.NotificationText.Should().Be("");
		}

		[Fact]
		public void NotificationtEmptyLink()
		{
			Notification notification = new Notification();
			notification.Link.Should().Be("");
		}

		[Fact]
		public void NotificationtEmptyReadNotification()
		{
			Notification notification = new Notification();
			notification.ReadNotification.Should().BeFalse();
		}

	}
}
