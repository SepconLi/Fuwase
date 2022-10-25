/*User Story: CD-US-1.6
 Subtask: CD-US-1.2.11
 Collaborators: Nathan, Mariana, Emmanuel, Álvaro
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Entities;
using Domain.Core.ValueObjects;

namespace Domain.Users.Entities
{
    public class BusinessUser:Client
    {
        public string Business_Name { get; set; }

        public string Legal_Document { get; set; } 

        public DateTime Alliance_Start { get; }

        public string Person_In_Charge { get; set; }

        public BusinessUser() : base()
        {
            Business_Name = null!;
            Legal_Document = null!;
            Alliance_Start = new DateTime();
            Person_In_Charge = null!;
        }
        public BusinessUser(string businessName, string legalDocument, 
            DateTime allianceStart, string personInCharge, string town, string district
            , string province, int strikes, string email, string userName, string password, int status
            , string hashedEmail, Boolean anomPreference, string role,int phoneNumber, string profilePicture) : base(email, userName,phoneNumber, password, status, 
                hashedEmail, anomPreference, role, town, district, province, strikes, profilePicture)
        {
            this.Business_Name = businessName;
            this.Legal_Document = legalDocument;
            this.Alliance_Start = allianceStart;
            this.Person_In_Charge = personInCharge;
        }
    }
}
