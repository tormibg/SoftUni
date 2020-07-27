namespace AssessmentApp.Web.ViewModels.TtPictures
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AssessmentApp.Web.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class TtPicturesInputViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [FileTypeValidation]
        public IEnumerable<IFormFile> Pictures { get; set; }

        [Required]
        public IEnumerable<string> EmailsList { get; set; }

        public IEnumerable<EmailsDropDownViewModel> Emails { get; set; }
    }
}
