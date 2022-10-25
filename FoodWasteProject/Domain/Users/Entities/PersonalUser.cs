/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of PersonalUser class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Users.Entities
{
    public class PersonalUser : Client
    {
        //Attributes
        public string IdNumber { get; set; } //Cedula
        public string Name { get; set; }
        public string LastName { get; set; }

        //PersonalUser Parameterized Constructor
        public PersonalUser(string idNumber, string name, string lastName, string email, string username, 
            int phoneNumber, string password, int status, string hashedEmail, Boolean anomPreference, string role,string town, string district, 
            string province, int strikes, string profilePicture) : base(email, username, phoneNumber, password, status, hashedEmail, anomPreference, role,
                town, district,  province, strikes, profilePicture)
        {
            IdNumber = idNumber;
            Name = name;
            LastName = lastName;
        }
        //PersonalUser Default Constructor
        public PersonalUser() 
        {
            Email = null!;
            UserName = null!;
            PhoneNumber = 00000000;
            Password = null!;
            Province = null!;
            District = null!;
            Town = null!;
            Strikes = 0;
            IdNumber = null!;
            Name = null!;
            LastName = null!;
            Profile_Picture = null!;
        }
    }

}
