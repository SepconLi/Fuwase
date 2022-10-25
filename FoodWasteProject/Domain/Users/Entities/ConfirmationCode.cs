/* CD-US-2.2 Forgot my password - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Implementation of ConfirmationCode class
 */
using Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users.Entities
{
    public class ConfirmationCode : Entity
    {
        public string Email { get; set; }
        public int Code { get; set; }

        public ConfirmationCode (string email, int code) 
        {
            Email = email;
            Code = code;
        }

        public ConfirmationCode()
        {
            Email = "";
            Code = 0;
        }
    }
}
