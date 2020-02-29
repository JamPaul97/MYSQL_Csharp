using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;    // for StreamReader
using LoginSystem;

namespace Tests
{
	public partial class Form1 : MetroFramework.Forms.MetroForm
	{
		public Form1()
		{
			InitializeComponent();
		}
		Connector cn = new Connector("http://127.0.0.1/loginSystem/","Test registration email",
			"Thank you for registaring. Please use this 'activation_key_placeholder' key to activate your account.");
		private async void Button1_Click(object sender, EventArgs e)
		{
			var a = cn.ResentActivationKey("paulosmantziaris@gmail.com");
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void Btn_login_Click(object sender, EventArgs e)
		{
			var response = cn.Login(username_txt.Text, password_txt.Text);
			if(response.Successful)
			{
				MetroFramework.MetroMessageBox.Show(this, "Login Succefull");
			}
			else
			{
				MetroFramework.MetroMessageBox.Show(this, response.Message);
			}
		}
		class test
		{
			public string username = "asdl";
			public string pass = "12332";
		}
		private void Btn_register_Click(object sender, EventArgs e)
		{
			var request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1/loginSystem/test.php");
			LoginSystem.UpdateDataObject d = new UpdateDataObject()
			{
				Coockie = "qR53JWVf2S",
				Username = "admintest",
				Data = new test
				{
					pass = "asdasdasd",
					username = "asdasd"
				}
			};
			var postData = JsonConvert.SerializeObject(d);
			var data = Encoding.ASCII.GetBytes(postData);
			request.Method = "POST";
			request.ContentType = "application/json";
			request.ContentLength = data.Length;

			using (var stream = request.GetRequestStream())
				stream.Write(data, 0, data.Length);
			var response = (HttpWebResponse)request.GetResponse();

			var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
		}
	}
}
