namespace LoginSystem
{
	/// <summary>
	/// Reponse class for the Refresh process.
	/// </summary>
	public class RefreshResponse
	{
		/// <summary>
		/// Username provided by the users.
		/// </summary>
		public string Username;
		/// <summary>
		/// A new Coockie for the current login session.
		/// </summary>
		public string Coockie;
		/// <summary>
		/// If true the Refresh was succefull.
		/// </summary>
		public bool Successful;
		/// <summary>
		/// Response Message.
		/// </summary>
		public string Message;
	}
}
