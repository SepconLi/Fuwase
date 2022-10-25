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

namespace Domain.Notifications.Repositories
{
    public interface INotificationRepository
    {
        /// <summary>
        /// Adds a Notification to the database
        /// </summary>
        Task SaveAsync(Notification notification);
        /// <summary>
		/// Returns a notification stored in the database that has the given email
		/// </summary>
		/// <param name="email"></param>
        Task<IList<Notification>> GetAllAsync(string email);

        Task readNotification(Notification notification);
    }
}
