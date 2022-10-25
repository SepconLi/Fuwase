using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Entities;
using Domain.Core.ValueObjects;

namespace Domain.Users.Entities
{
    public class Administrator : User
    {
        public string AdminID { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        //User Constructor
        public Administrator(string email, string username, int phoneNumber, string password, int status, 
            string hashedEmail, Boolean anomPreference, string role,string adminID, string name, string lastName, string profilePicture) :base(email, username, phoneNumber, 
                password, status, hashedEmail, anomPreference, role, profilePicture)
        {
            AdminID = adminID;
            Name = name;
            LastName = lastName;
        }

        public Administrator()
        {
            AdminID = null!;
            Name = null!;
            LastName = null!;
        }
    }
}
