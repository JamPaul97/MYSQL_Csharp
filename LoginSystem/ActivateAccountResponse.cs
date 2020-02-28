namespace LoginSystem
{
	/// <summary>
	/// Reponse class for the Activation process.
	/// </summary>
	public class ActivateAccountResponse
	{
		/// <summary>
		/// The email provided by the user
		/// </summary>
		public string Email;
		/// <summary>
		/// If true the activation was succefull.
		/// </summary>
		public bool Successful;
		/// <summary>
		/// Response message.
		/// </summary>
		public string Message;
	}
}
