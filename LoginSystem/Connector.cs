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


		public Connector(string Server,string emailSubject,string emailMessage)
		{
			this.Server = Server;
			this.emailSubject = emailSubject;
			this.emailMessage = emailMessage;
		}


		public RegisterResponse Register(string username,string email,string password)
		{
						//gather post info
						//$username = $_POST['username'];
						//$password = $_POST['password'];
						//$email = $_POST['email'];
						//$trn_date = $_POST['date'];
						//$emailSubject = $_POST['emailSubject'];
						//$emailMessage = $_POST['emailMessage']; //MustContains 'activation_key_placeholder' somewhere

			var request = (HttpWebRequest)WebRequest.Create(this.Server + "register.php");
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
		public LoginResponse Login(string username,string password)
		{
			var request = (HttpWebRequest)WebRequest.Create(this.Server + "login.php");
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
			var request = (HttpWebRequest)WebRequest.Create(this.Server + "changePassword.php");
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
		public RefreshResponse RefreshLogin(string username,string password)
		{
			var request = (HttpWebRequest)WebRequest.Create(this.Server + "refreshLogin.php");
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
		public ActivateAccountResponse ActivateAccont(string email,string activation_key)
		{
			var request = (HttpWebRequest)WebRequest.Create(this.Server + "activateAccount.php");
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
		public ResendActivationKeyResponse ResentActivationKey(string email)
		{
			var request = (HttpWebRequest)WebRequest.Create(this.Server + "resentActivationKey.php");
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
