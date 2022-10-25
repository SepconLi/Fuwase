/* CD-US-1.4 Add link to confirmation code email - Core Dummpers
 * 
 * Collaborators:
 * - Mariana Murillo
 * 
 * - Summary: Implementation of RedirectInformation class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Domain.Utilities.Entities
{
    public class RedirectInformation
    {
        // RedirectInformation attributes
        public string Route { get; set; }
        public string Email { get; set; }
        public string Param { get; set; }
        public string Key { get; set; }
        public string Hash { get; set; }
        public DateTime Expiration { get; set; }

        //RedirectInformation Default Constructor
        public RedirectInformation()
        {
            Route = null!;
            Email = null!;
            Param = null!;
            Key = null!;
            Hash = null!;
            Expiration = new DateTime();
        }

        //RedirectInformation Parameterized Constructor
        public RedirectInformation(string route, string email, string param)
        {
            Route = route;
            Email = email;
            Param = param;
            Random key = new Random();
            int _key = key.Next(100000, 1000000);
            Key = _key.ToString();
            string hash = BC.HashPassword(Email + Key);
            hash = hash.Replace('/', '*');
            hash = hash.Replace('"', '*');
            hash = hash.Replace('.', '*');
            hash = hash.Replace(';', '*');
            Hash = hash;
            Expiration = DateTime.Today.AddDays(1);
        }

        /// <summary>
        /// Verifies if the Expiration date has passed.
        /// </summary>
        /// <returns></returns>
        public Boolean VerifyExpirationDate()
        {
            if (DateTime.Compare(DateTime.Today, Expiration) < 0)
            {
                return false;
            }
            return true;
        }
    }
}
