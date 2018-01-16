﻿using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Models.BindingModels.Users
{
	public class UserEditBm
	{

		[Required]
		public string Name { get; set; }

		[Required]
		public string Email { get; set; }
	}
}