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
+-Summary: Component that makes the Messages.
+*/


/* Project includes */
using Domain.Core.Entities;

/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Messages.Entities
{
    public class Message : Entity
    {
        /**  Attributes **/

        // Basic attributes

        public DateTime Date_Message { get; set; }
        public string Text { get; set; }
        public string SenderId { get; set; }
        public int OrderId { get; set; }



        public Message(int room, string username, string body)
        {
            Date_Message = DateTime.Now;
            Text = body;
            SenderId = username;
            OrderId = room;
        }
        public Message(int id, DateTime date_Message, string text, string senderId, int orderId)
        {
            Id = id;
            Date_Message = date_Message;
            Text = text;
            SenderId = senderId;
            OrderId = orderId;
        }




        public bool IsNotice => Text.StartsWith("[Notice]");
        public bool IsLocation => Text.StartsWith("[Location]");
        //public string CSS => Mine ? "sent" : "received";
        public bool IsImage => Text.StartsWith("[Image]");
    }
}
