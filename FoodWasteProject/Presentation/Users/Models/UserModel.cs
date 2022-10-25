
/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary:  user data model
 */

namespace Presentation.Users.Models
{

	public abstract class UserModel
	{
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public int Status { get; set; }
		public int PhoneNumber { get; set; }
		public string HashedEmail { get; set; }
		public string ProfilePicture { get; set; }

		/// <summary>
		/// parameterized constructor of user entity
		/// </summary>
		/// <param name="email"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="status"></param>
		/// <param name="phonenumber"></param>
		public UserModel(string email, string username, string password, int status, int phonenumber, string hashedEmail, string profilePicture)
        {
			Email = email;
			UserName = username;
			Password = password;
			Status = status;
			HashedEmail = hashedEmail;
			PhoneNumber = phonenumber;
			ProfilePicture = profilePicture;
		}

		/// <summary>
		/// empty constructor of personal user entity
		/// </summary>
		public UserModel()
        {
			Email = null!;
			UserName = null!;
			Password = null!;
			PhoneNumber = 00000000;
			Status = 0;
			HashedEmail = null!;
			ProfilePicture = null!;
        }

	}
}
