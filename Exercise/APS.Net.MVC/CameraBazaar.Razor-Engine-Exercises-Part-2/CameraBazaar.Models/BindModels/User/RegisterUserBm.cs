using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using CameraBazaar.Models.Constants;

namespace CameraBazaar.Models.BindModels.User
{
    public class RegisterUserBm
    {
        [Username, Required]
        [DisplayName("Username: ")]
        public String Username { get; set; }

        [EmailAddress, Required]
        [DisplayName("Email: ")]
        public String Email { get; set; }

        [RegularExpression(ValidationRegularExpressions.PasswordRegex,
            ErrorMessage = ValidationMessages.PasswordValidationMessage), Required]
        [DisplayName("Password: ")]
        public String Password { get; set; }

        [RegularExpression(ValidationRegularExpressions.PasswordRegex,
            ErrorMessage = ValidationMessages.PasswordValidationMessage), Required]
        [DisplayName("Confirm Password: ")]
        public String ConfirmPassword { get; set; }

        [RegularExpression(ValidationRegularExpressions.PhoneRegex, ErrorMessage = ValidationMessages.PhoneValidationMessage)]
        [DisplayName("Phone")]
        public String Phone { get; set; }
    }
}