
/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Personal user data model
 */

namespace Presentation.Users.Models
{
	public class PersonalUserModel : ClientModel
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public string IdNumber { get; set; }

        /// <summary>
        /// parameterized constructor of personal user entity
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="status"></param>
        /// <param name="phonenumber"></param>
        /// <param name="province"></param>
        /// <param name="district"></param>
        /// <param name="town"></param>
        /// <param name="strikes"></param>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <param name="idnumber"></param>
        /// <param name="profilePicture"></param>
		public PersonalUserModel(string email, string username, string password, int status, int phonenumber,  string hashedEmail, string province, string district, 
			string town, int strikes, string name, string lastname, string idnumber, string profilePicture) :
			base(email, username, password, status, phonenumber, hashedEmail, province, district, town, strikes, profilePicture)
        {
			Name = name;
			LastName = lastname;
			IdNumber = idnumber;
        }

        /// <summary>
        /// parameterized constructor of personal user entity
        /// </summary>
        public PersonalUserModel()
        {
            Email = null!;
            UserName = null!;
            PhoneNumber = 00000000;
            Password = null!;
            Status = 0;
            Province = null;
            District = null;
            Town = null;
            Strikes = 0;
            IdNumber = null!;
            Name = null!;
            LastName = null!;
            ProfilePicture = null!;
        }

    }
}
