namespace LoginSystem
{
	/// <summary>
	/// Reponse class for the Login process.
	/// </summary>
	public class LoginResponse
	{
		/// <summary>
		/// Username provided by the user
		/// </summary>
		public string Username;
		/// <summary>
		/// A new Coockie for the current login session.
		/// </summary>
		public string Coockie;
		/// <summary>
		/// If true the login was completed.
		/// </summary>
		public bool Successful;
		/// <summary>
		/// Response Message.
		/// </summary>
		public string Message;
	}
}
