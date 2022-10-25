/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of Client father class
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Domain.Users.Entities
{
    public class Client : User
    {
        //Client Attributes
        public string Town { get; set; }

        public string District { get; set; }

        public string Province { get; set; }

        public int Strikes { get; set; }

        //Client Parameterized Constructor
        public Client(string email, string username, int phoneNumber, string password, int status, string hashedEmail, Boolean anomPreference, string role, string town,
            string district, string province, int strikes, string profilePicture) : base(email, username, phoneNumber, password, status, hashedEmail, anomPreference, role, profilePicture)
        {
            Town = town;
            District = district;
            Province = province;
            Strikes = strikes;

        }

        //Client Default Constructor
        public Client() 
        {
            Town = null!;
            District = null!;
            Province = null!;
            Strikes = 0;
        }
    }
}
