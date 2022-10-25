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
+-Summary: Component that makes the Noticatios.
+*/


/* Project includes */

using Domain.Notifications.Entities;
using Domain.Notifications.Repositories;

/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notifications.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _NotificationRepository;
        public int Count { get; set; } = 0;

        public event Action OnChange;
        //  OnChange?.Invoke();

        public NotificationService(INotificationRepository notificationRepository)
        {
            _NotificationRepository = notificationRepository;
        }
        /// <summary>
        /// service to add the notifications 
        /// </summary>
        /// <param name="notification"></param>
        public async Task addNotification(Notification notification)
        {
            await _NotificationRepository.SaveAsync(notification);
        }
        /// <summary>
        /// Gets notification using specified email
        /// </summary>
        /// <param name="email"></param>
        public async Task<IList<Notification>> GetNotificationByEmailAsync(string email)
        {
            return await _NotificationRepository.GetAllAsync(email);
        }
        public async Task readNotificationAsync(Notification notification)
        {
            await _NotificationRepository.readNotification(notification);
        }
        public async Task<int> GetNumberUnRead(string email) {
            int counter = 0;
            IList<Notification>  notifications =  await _NotificationRepository.GetAllAsync(email);
            foreach (var item in notifications) {
                if (!item.ReadNotification) {
                    counter++;
                }
            }
            return counter;
        }

    }
}
