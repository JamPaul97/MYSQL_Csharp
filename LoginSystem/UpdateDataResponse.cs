using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystem
{
	public class UpdateDataResponse
	{
		/// <summary>
		/// Username provided
		/// </summary>
		public string Username;
		/// <summary>
		/// Data provided
		/// </summary>
		public dynamic Data;
		/// <summary>
		/// If true data update was completed.
		/// </summary>
		public bool Successful;
		/// <summary>
		/// Reponse message.
		/// </summary>
		public string Message;
	}
}
