using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Models.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
