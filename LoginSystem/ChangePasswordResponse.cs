namespace LoginSystem
{
	/// <summary>
	/// Reponse class for the Change Password process.
	/// </summary>
	public class ChangePasswordResponse
	{
		/// <summary>
		/// Username provided by the user
		/// </summary>
		public string Username;
		/// <summary>
		/// If true the password was changed succefull.
		/// </summary>
		public bool Successful;
		/// <summary>
		/// Response message.
		/// </summary>
		public string Message;
	}
}
