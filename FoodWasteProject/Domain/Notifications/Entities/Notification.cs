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

using Domain.Core.Entities;

/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Notifications.Entities
{
    public class Notification : Entity
    {
        /**  Attributes **/

        // Basic attributes
        public string  Email { get; set; }
        public string NotificationText { get; set; }
        public string Link { get; set; }
        public bool ReadNotification { get; set; }
        public DateTime TimeNotification { get; set; }

        /**  Methods **/

        // Basic constructor for Notification
        public Notification()
        {
            Email = "";
            NotificationText = "";
            Link = "";
            ReadNotification = false;
            TimeNotification = DateTime.Now;
        }
        public Notification(string email, string notificationText, string link, bool readNotification, DateTime timeNotification)
        {
           Email = email;
           NotificationText = notificationText;
           Link = link;
           ReadNotification = readNotification;
           TimeNotification = timeNotification;
        }

        public Notification(int id, string email, string notificationText, string link, bool readNotification, DateTime timeNotifaction)
        {
            Id = id;
            Email = email;
            NotificationText = notificationText;
            Link = link;
            ReadNotification = readNotification;
            TimeNotification = timeNotifaction;
        }
    }

}
