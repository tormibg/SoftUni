using Microsoft.Build.Framework;

namespace LearningSystem.Models.ViewModels.Users
{
	public class UserEditVm
	{

		[Required]
		public string Name { get; set; }

		[Required]
		public string Email { get; set; }
	}
}