using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CreateUser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PasswordAttribute : ValidationAttribute
    {
        private readonly int _passwordMinLen, _passwordMaxLen;

        public PasswordAttribute(int passwordMinLen = 6, int passwordMaxLen = 50)
        {
            this._passwordMinLen = passwordMinLen;
            this._passwordMaxLen = passwordMaxLen;
        }

        public bool ShouldContainAtLeastOneLowerCaseLetter { get; set; }

        public bool ShouldContainAtLeastOneUpperCaseLetter { get; set; }

        public bool ShouldContainAtLeastOneDigit { get; set; }

        public bool ShouldContainAtLeastOneSpecialSimbol { get; set; }

        public override bool IsValid(object value)
        {
            string valueString = value as string;

            if (valueString == null)
            {
                throw new ArgumentException("Property must be a string");
            }

            if (valueString.Length < this._passwordMinLen || valueString.Length > this._passwordMaxLen || this._passwordMinLen > this._passwordMaxLen)
            {
                return false;
            }

            if (this.ShouldContainAtLeastOneDigit && !this.IfContainsDigit(valueString))
            {
                return false;
            }

            if (this.ShouldContainAtLeastOneLowerCaseLetter && !this.IfContainsOneLowerCaseLetter(valueString))
            {
                return false;
            }

            if (this.ShouldContainAtLeastOneUpperCaseLetter && !this.IfContainsOneUpperCaseLetter(valueString))
            {
                return false;
            }

            if (this.ShouldContainAtLeastOneSpecialSimbol && !this.IfContainsOneSpecialSimbol(valueString))
            {
                return false;
            }

            return true;
        }

        private bool IfContainsOneSpecialSimbol(string valueString)
        {
            char[] specialSymbols = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?' };
            return specialSymbols.Any(valueString.Contains);
        }

        private bool IfContainsOneUpperCaseLetter(string valueString)
        {
            return valueString.Count(char.IsUpper) != 0;
        }

        private bool IfContainsOneLowerCaseLetter(string valueString)
        {
            return valueString.Count(char.IsLower) != 0;
        }

        private bool IfContainsDigit(string valueString)
        {
            return valueString.Count(char.IsDigit) != 0;
        }
    }
}