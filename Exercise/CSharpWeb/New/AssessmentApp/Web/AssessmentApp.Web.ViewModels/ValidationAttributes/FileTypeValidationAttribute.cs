namespace AssessmentApp.Web.ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    using Microsoft.AspNetCore.Http;

    public class FileTypeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // List<IFormFile> inputFiles = (List<IFormFile>)value;
            List<IFormFile> inputFiles = value as List<IFormFile>;
            var result = false;
            foreach (var file in inputFiles)
            {
                result = FormFileExtensions.IsImage(file);
                if (result == false)
                {
                    return new ValidationResult("Невалиден файл. Моля само снимки !");
                }
            }

            return ValidationResult.Success;
        }
    }
}
