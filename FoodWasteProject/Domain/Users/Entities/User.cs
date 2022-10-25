/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of User father class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Users.Entities
{
    public class User : AggregateRoot
    {
        //User attributes
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public int Status { get; set; }
        public string HashedEmail { get; set; }
        public Boolean Anom_Preference { get; set; }
        public string Role { get; set; }
        public string Profile_Picture { get; set; }

        //User Parameterized Constructor
        public User(string email, string username,
            int phoneNumber, string password, int status, string hashed, Boolean anomPreference, string role, string profilePicture)
        {
            Email = email;
            UserName = username;
            PhoneNumber = phoneNumber; 
            Password = password;
            Status = status;
            HashedEmail = hashed;
            Anom_Preference = anomPreference;
            Role = role;
            Profile_Picture = profilePicture;
        }
        //User Default Constructor
        public User()
        {
            Email = null!;
            UserName = null!;
            PhoneNumber = 0;
            Password = null!;
            Status = 0;
            HashedEmail = "";
            Anom_Preference = false;
            Role = null!;
            Profile_Picture = null!;
        }
    }
}
