
/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Business user data model
 */

namespace Presentation.Users.Models
{
    public class BusinessUserModel : ClientModel
    {
        public string Business_Name { get; set; }

        public string Legal_Document { get; set; }

        public DateTime Alliance_Start { get; }

        public string Person_In_Charge { get; set; }

        public BusinessUserModel(string email, string username, string password, int status, int phonenumber, 
            string hashedEmail, string province, string district,
            string town, int strikes, string business_name, string legalDocument, string personInCharge, string profilePicture) :
            base(email, username, password, status, phonenumber, hashedEmail, province, district, town, strikes, profilePicture)
        {
            Business_Name = business_name;
            Legal_Document = legalDocument;
            Person_In_Charge = personInCharge;
            Alliance_Start = DateTime.Today;
        }

        /// <summary>
        /// parameterized constructor of personal user entity
        /// </summary>
        public BusinessUserModel()
        {
            Email = "";
            UserName = "";
            PhoneNumber = 00000000;
            Password = "";
            Province = "";
            District = "";
            Town = "";
            Strikes = 0;
            Business_Name = "";
            Legal_Document = "";
            Person_In_Charge = "";
            Alliance_Start = DateTime.Today;
            Status = 0;
            ProfilePicture = "";
        }
    }
}
