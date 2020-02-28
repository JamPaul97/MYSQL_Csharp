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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		LoginSystem.Connector cn = new Connector("http://127.0.0.1/login/","Test registration email",
			"Thank you for registaring. Please use this 'activation_key_placeholder' key to activate your account.");
		private async void Button1_Click(object sender, EventArgs e)
		{
			var a = cn.ResentActivationKey("paulosmantziaris@gmail.com");
		}
		
	}
}
