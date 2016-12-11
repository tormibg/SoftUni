using System;
using System.ComponentModel.DataAnnotations;

namespace CreateUser.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            string strValue = value as string;

            if (!strValue.StartsWith("#"))
            {
                return false;
            }

            if (strValue.Length > 20)
            {
                return false;
            }

            if (strValue.Contains(" ") || strValue.Contains("  "))
            {
                return false;
            }

            return true;
        }
    }
}