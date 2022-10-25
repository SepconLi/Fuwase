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


using Domain.Core.Repositories;
using Domain.Notifications.Entities;
using Domain.Notifications.Repositories;
using Infrastructure.Products;
using Microsoft.EntityFrameworkCore;


/* System includes */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Notifications.Repositories
{
    internal class NotificationRepository : INotificationRepository
    {

        private readonly NotificationDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public NotificationRepository(NotificationDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        /// <summary>
		/// Adds a Notification to the database
		/// </summary>
		/// <param name="notification"></param>

        public async Task SaveAsync(Notification notification)
        {
            _dbContext.Notifications.Add(notification);
           
            await _dbContext.SaveEntitiesAsync();
        }
        /// <summary>
        /// Returns a Notification stored in the database that has the given id
        /// </summary>
        /// <param name="email"></param>
        public async Task<IList<Notification>> GetAllAsync(string email)
        {
            return await _dbContext.Notifications.Where(d => d.Email == email).
                Select(t => new Notification(t.Id, t.Email, t.NotificationText, t.Link, t.ReadNotification, t.TimeNotification)).
                ToListAsync();
        }

        public async Task readNotification(Notification notification)
        {
            notification.ReadNotification = true;
            _dbContext.Update(notification);
            await _dbContext.SaveEntitiesAsync();
        }

    }
}
