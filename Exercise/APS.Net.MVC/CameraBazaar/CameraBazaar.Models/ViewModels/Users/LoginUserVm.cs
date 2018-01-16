using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Models.ViewModels.Users
{
    public class LoginUserVm
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}