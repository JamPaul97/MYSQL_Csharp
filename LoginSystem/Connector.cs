using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;    // for StreamReader

namespace LoginSystem
{
    public class Connector
    {
		private string Server = "http://127.0.0.1/login/";
		private string Coockie = null;
		private string emailSubject = string.Empty;
		private string emailMessage = string.Empty; ////MustContains 'activation_key_placeholder' somewhere
		private string RegisterURL = "register.php";
		private string LoginURL = "login.php";
		private string ChangePasswordURL = "changePassword.php";
		private string RefreshLoginURL = "refreshLogin.php";
		private string ActivateAccountURL = "activateAccount.php";
		private string ResentActivationKeyURL = "resentActivationKey.php";
		/// <summary>
		/// Change the Change Password .php name
		/// </summary>
		public string ChangePasswordPage
		{
			get { return this.ChangePasswordURL; }
			set { this.ChangePasswordURL = value; }
		}
		/// <summary>
		/// Change the Change Register .php name
		/// </summary>
		public string RegisterPage
		{
			get { return this.RegisterURL; }
			set { this.RegisterURL = value; }
		}
		/// <summary>
		/// Change the Login .php name
		/// </summary>
		public string LoginPage
		{
			get { return this.LoginURL; }
			set { this.LoginURL = value; }
		}
		/// <summary>
		/// Change the Refresh Login .php name
		/// </summary>
		public string RefreshLoginPage
		{
			get { return this.RefreshLoginURL; }
			set { this.RefreshLoginURL = value; }
		}
		/// <summary>
		/// Change the Activate Acccount .php name
		/// </summary>
		public string ActivateAccountPage
		{
			get { return this.ActivateAccountURL; }
			set { this.ActivateAccountURL = value; }
		}
		/// <summary>
		/// Change the Resent Activation Key .php name
		/// </summary>
		public string ResentActivationKeyPage
		{
			get { return this.ResentActivationKeyURL; }
			set { this.ResentActivationKeyURL = value; }
		}
		/// <summary>
		/// Change the main Body of the Activation Email. IMPORTANT***This message must contains 'activation_key_placeholder' keyword somewhere.This CAN be an HTML String. Note all the 'activation_key_placeholder' keywords will be replaced with the activation key upon sending.
		/// </summary>
		public string EmailMessage
		{
			get { return this.emailMessage; }
			set
			{
				if (value == string.Empty)
					throw new Exception("Email Message body can't be empty.");
				else if (!value.Contains("activation_key_placeholder"))
					throw new Exception("Emaim message body must contain 'activation_key_placeholder' keyword somewhere");
				this.emailMessage = value;
			}
		}
		/// <summary>
		/// Change the subject of the Activation Email
		/// </summary>
		public string EmailSubject
		{
			get { return this.emailSubject; }
			set { this.emailSubject = value; }
		}


		/// <summary>
		/// Create a new Login System Connector
		/// </summary>
		/// <param name="Server">This your server's url contains the php files. Note that the url must directly point to the files. For example ''www.someSite.com/loginSystem/' that means that in the folder loginSystem on my site there are all the php files.</param>
		/// <param name="emailSubject">The Subject form the activation email</param>
		/// <param name="emailMessage">The main Message body of the activation email.IMPORTANT***This message must contains 'activation_key_placeholder' keyword somewhere.This CAN be an HTML String. Note all the 'activation_key_placeholder' keywords will be replaced with the activation key upon sending.</param>
		public Connector(string Server,string emailSubject,string emailMessage)
		{
			this.Server = Server;
			this.EmailMessage = emailSubject;
			this.EmailSubject = emailMessage;
		}

		/// <summary>
		/// Register a user to your system.
		/// </summary>
		/// <param name="username">the username chossen</param>
		/// <param name="email">The email chossen</param>
		/// <param name="password">The password chosses. Note that the password will be hashed inside the database. This string must be the password of the user as is.</param>
		/// <returns>Chechk the RegisterResponse class for more info about the response</returns>
		public RegisterResponse Register(string username,string email,string password)
		{
						//gather post info
						//$username = $_POST['username'];
						//$password = $_POST['password'];
						//$email = $_POST['email'];
						//$trn_date = $_POST['date'];
						//$emailSubject = $_POST['emailSubject'];
						//$emailMessage = $_POST['emailMessage']; //MustContains 'activation_key_placeholder' somewhere

			var request = (HttpWebRequest)WebRequest.Create(this.Server + RegisterURL);
			var postData = "username=" + Uri.EscapeDataString(username);
			postData += "&email=" + Uri.EscapeDataString(email);
			postData += "&password=" + Uri.EscapeDataString(password);
			postData += "&date=" + Uri.EscapeDataString(DateTime.Now.ToString());
			postData += "&emailSubject=" + this.emailSubject;
			postData += "&emailMessage=" + this.emailMessage;
			var data = Encoding.ASCII.GetBytes(postData);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = data.Length;

			using (var stream = request.GetRequestStream())
				stream.Write(data, 0, data.Length);
			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return JsonConvert.DeserializeObject<RegisterResponse>(responseString);
		}
		/// <summary>
		/// Login a user from your system.
		/// </summary>
		/// <param name="username">The username of the user.</param>
		/// <param name="password">The password of the user. Note that this string must be the password as is, the hashing and checking will be made by the server.</param>
		/// <returns>Check LoginResponse class for more info about the response.</returns>
		public LoginResponse Login(string username,string password)
		{
			var request = (HttpWebRequest)WebRequest.Create(this.Server + LoginURL);
			var postData = "username=" + Uri.EscapeDataString(username);
			postData += "&password=" + Uri.EscapeDataString(password);
			var data = Encoding.ASCII.GetBytes(postData);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = data.Length;

			using (var stream = request.GetRequestStream())
				stream.Write(data, 0, data.Length);
			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			LoginResponse result = JsonConvert.DeserializeObject<LoginResponse>(responseString);
			if (result.Successful)
				this.Coockie = result.Coockie;
			return result;
		}
		/// <summary>
		/// Change the password of the selected user.Note that the user must first be logged in before changing the password.
		/// </summary>
		/// <param name="username">The username of the user.</param>
		/// <param name="password">The password of the user. Note that this string must be the password as is, the hashing and checking will be made by the server.</param>
		/// <param name="newPassword">The new password for the user. Note that this string must be the password as is, the hashing and checking will be made by the server.</param>
		/// <returns>Check the ChangePasswordReponse class for more info about the response.</returns>
		public ChangePasswordResponse ChangePassword(string username,string password, string newPassword)
		{
			if(this.Coockie == null || this.Coockie == string.Empty)
			{
				return new ChangePasswordResponse()
				{
					Message = "The user's coockie is empty. Login before changing password",
					Successful = false,
					Username = username
				};
			}
			var request = (HttpWebRequest)WebRequest.Create(this.Server + ChangePasswordURL);
			var postData = "username=" + Uri.EscapeDataString(username);
			postData += "&password=" + Uri.EscapeDataString(password);
			postData += "&coockie=" + Uri.EscapeDataString(this.Coockie);
			postData += "&newPassword=" + Uri.EscapeDataString(newPassword);
			var data = Encoding.ASCII.GetBytes(postData);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = data.Length;

			using (var stream = request.GetRequestStream())
				stream.Write(data, 0, data.Length);
			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return JsonConvert.DeserializeObject<ChangePasswordResponse>(responseString);
			
		}
		/// <summary>
		/// Refresh the login of the user. This is usefull if the account has been loggen in by another machine. This will refresh the coockie for this instance of the program.
		/// </summary>
		/// <param name="username">The username of the user.</param>
		/// <param name="password">The password of the user. Note that this string must be the password as is, the hashing and checking will be made by the server.</param>
		/// <returns>Check the RefreshResponse class for more info about the response.</returns>
		public RefreshResponse RefreshLogin(string username,string password)
		{
			var request = (HttpWebRequest)WebRequest.Create(this.Server + RefreshLoginURL);
			var postData = "username=" + Uri.EscapeDataString(username);
			postData += "&password=" + Uri.EscapeDataString(password);
			var data = Encoding.ASCII.GetBytes(postData);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = data.Length;

			using (var stream = request.GetRequestStream())
				stream.Write(data, 0, data.Length);
			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			RefreshResponse result = JsonConvert.DeserializeObject<RefreshResponse>(responseString);
			if (result.Successful)
				this.Coockie = result.Coockie;
			return result;
		}
		/// <summary>
		/// Activate the account of a registered user.
		/// </summary>
		/// <param name="email">The email of the account to be activated.</param>
		/// <param name="activation_key">The activation key for the account</param>
		/// <returns>Check the ActivateAccountResponse class for more info about the reponse.</returns>
		public ActivateAccountResponse ActivateAccount(string email,string activation_key)
		{
			var request = (HttpWebRequest)WebRequest.Create(this.Server + ActivateAccountURL);
			var postData = "email=" + Uri.EscapeDataString(email);
			postData += "&activationKey=" + Uri.EscapeDataString(activation_key);
			var data = Encoding.ASCII.GetBytes(postData);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = data.Length;

			using (var stream = request.GetRequestStream())
				stream.Write(data, 0, data.Length);
			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return JsonConvert.DeserializeObject<ActivateAccountResponse>(responseString);
		}
		/// <summary>
		/// Resent the activation key to the user. Note that the email provided is the email for the registered user and not an email for the key tobe sented to.
		/// </summary>
		/// <param name="email">The user's email.</param>
		/// <returns>Check the ResendActivationKeyResponse class for more info about the response.</returns>
		public ResendActivationKeyResponse ResentActivationKey(string email)
		{
			var request = (HttpWebRequest)WebRequest.Create(this.Server + ResentActivationKeyURL);
			var postData = "email=" + Uri.EscapeDataString(email);
			postData += "&emailSubject=" + this.emailSubject;
			postData += "&emailMessage=" + this.emailMessage;
			var data = Encoding.ASCII.GetBytes(postData);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = data.Length;

			using (var stream = request.GetRequestStream())
				stream.Write(data, 0, data.Length);
			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return JsonConvert.DeserializeObject<ResendActivationKeyResponse>(responseString);
		}

	}

}
