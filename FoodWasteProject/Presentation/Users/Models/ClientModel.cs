/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Client entity data model
 */

namespace Presentation.Users.Models
{
	public abstract class ClientModel : UserModel
	{
		public string? Province { get; set; }
		public string? District { get; set; }
		public string? Town { get; set; }
		public int Strikes { get; set; }

        /// <summary>
        /// parameterized constructor of client entity
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
        /// <param name="profilePicture"></param>
		public ClientModel(string email, string username, string password, int status, int phonenumber, string hashedEmail, string province, 
			string district, string town, int strikes, string profilePicture):
			base(email, username, password, status, phonenumber, hashedEmail, profilePicture)
        {
			Province = province;
			District = district;
			Town = town;
			Strikes = strikes;
        }

        /// <summary>
        ///  empty constructor of client entity
        /// </summary>
        public ClientModel()
        {
            Email = null!;
            UserName = null!;
            Password = null!;
            Status = 0;
            PhoneNumber = 00000000;
            Province = null;
            District = null;
            Town = null;
            Strikes = 0;
            ProfilePicture = null!;
        }

    }
}
