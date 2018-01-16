using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.EntityModels
{
	public class User
	{
		public User()
		{
			this.Cameras = new HashSet<Camera>();
		}

		public int Id { get; set; }

		[Username, Required]
		public String Username { get; set; }

		[EmailAddress, Required]
		public String Email { get; set; }

		[RegularExpression(PasswordRegex,
			ErrorMessage = PasswordValidationMessage), Required]
		public String Password { get; set; }

		[RegularExpression(PhoneRegex, ErrorMessage = PhoneValidationMessage)]
		public String Phone { get; set; }

		public DateTime? LastLoginTime { get; set; }

		public ICollection<Camera> Cameras { get; set; }

	}
}
