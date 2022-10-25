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

/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notifications
{
    public interface INotificationService
    {
        // notify the other components of any changes
        event Action OnChange;
        int Count { get; set;  }
        /// <summary>
        /// Gets notification using specified email
        /// </summary>
        /// <param name="email"></param>
        Task<IList<Notification>> GetNotificationByEmailAsync(string email);
        /// <summary>
        /// service to add the notifications 
        /// </summary>
        /// <param name="notification"></param>
        Task addNotification(Notification notification);

        Task readNotificationAsync(Notification notification);
        Task<int> GetNumberUnRead(string email);
    }
}
