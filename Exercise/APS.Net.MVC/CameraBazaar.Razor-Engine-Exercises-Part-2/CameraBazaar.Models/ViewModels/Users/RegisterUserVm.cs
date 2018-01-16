using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;
using static CameraBazaar.Models.Constants.ValidationMessages;

namespace CameraBazaar.Models.ViewModels.Users
{
    public class RegisterUserVm
    {
        [Username, Required]
        [DisplayName("Username: ")]
        public String Username { get; set; }

        [EmailAddress, Required]
        [DisplayName("Email: ")]
        public String Email { get; set; }

        [RegularExpression(PasswordRegex,
            ErrorMessage = PasswordValidationMessage), Required]
        [DisplayName("Password: ")]
        public String Password { get; set; }

        [RegularExpression(PasswordRegex,
            ErrorMessage = PasswordValidationMessage), Required]
        [DisplayName("Confirm Password: ")]
        public String ConfirmPassword { get; set; }

        [RegularExpression(PhoneRegex, ErrorMessage = PhoneValidationMessage)]
        [DisplayName("Phone")]
        public String Phone { get; set; }
    }
}