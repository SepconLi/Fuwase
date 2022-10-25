using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.DTOs
{
    public class InformacionDTO
    {
        public string Email { get; }
        public string Name { get; }
        public string LastName { get; }

        public string UserName { get; }

        public bool Anom_Preference { get; }

        public InformacionDTO(string email,string name, string lastName ) {
            Email = email;
            Name = name ;
            LastName = lastName;
        }

        public InformacionDTO(string email, string name)
        {
            Email = email;
            Name = name;
        }
        public InformacionDTO( )
        {
            Email = "";
            Name = "";
            LastName = "";
        }
        public InformacionDTO(string email, bool anom_Preference,string userName)
        {
            Email = email;
            Anom_Preference = anom_Preference;
            UserName = userName;
        }
    }
}
