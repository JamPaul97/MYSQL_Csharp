using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystem
{
	/// <summary>
	/// Reponse class for the Registration process.
	/// </summary>
	public class RegisterResponse
	{
		/// <summary>
		/// Username chosen by the user. 
		/// </summary>
		public string Username;
		/// <summary>
		/// Time and date of the registration of the account
		/// </summary>
		public string Date;
		/// <summary>
		/// Email chosen by the user.
		/// </summary>
		public string Email;
		/// <summary>
		/// If true the registration was completed.
		/// </summary>
		public bool Successful;
		/// <summary>
		/// Reponse message.
		/// </summary>
		public string Message;
	}
}
