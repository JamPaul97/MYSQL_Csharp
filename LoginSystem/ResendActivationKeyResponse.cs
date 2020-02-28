namespace LoginSystem
{
	/// <summary>
	/// Reponse class for the Resend Activation Key process.
	/// </summary>
	public class ResendActivationKeyResponse
	{
		/// <summary>
		/// Email provided by the user.
		/// </summary>
		public string Email;
		/// <summary>
		/// If true the key was sented succefully
		/// </summary>
		public bool Successful;
		/// <summary>
		/// Reponse message.
		/// </summary>
		public string Message;
	}
}
