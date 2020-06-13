namespace AssessmentApp.Web.ViewModels.TTPictures
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AssessmentApp.Web.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class TPPicturesInputViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [FileTypeValidation]
        public IEnumerable<IFormFile> Pictures { get; set; }
    }
}
