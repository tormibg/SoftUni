using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CreateUser.Attributes
{
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueString = value as string;
            if (valueString == null)
            {
                throw new ArgumentException("Property must be a string");
            }

            string regularExpressinString = @"([a-zA-Z0-9][a-zA-Z_\-.]*[a-zA-Z0-9])@([a-zA-Z-]+\.[a-zA-Z-]+(\.[a-zA-Z-]+)*)";
            Regex regex = new Regex(regularExpressinString);
            if (!regex.IsMatch(valueString))
            {
                return false;
            }

            return true;
        }
    }
}