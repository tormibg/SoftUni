using System;

namespace CameraBazaar.Models.EntityModels
{
	public class Login
	{
		public DateTime LoginStamp { get; set; }

		public int Id { get; set; }

		public string SessionId { get; set; }

		public virtual User User { get; set; }

		public bool IsActive { get; set; }
	}
}