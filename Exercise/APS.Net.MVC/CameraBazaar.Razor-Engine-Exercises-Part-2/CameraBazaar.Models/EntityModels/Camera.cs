using System.ComponentModel.DataAnnotations;
using CameraBazaar.Models.Attributes;
using CameraBazaar.Models.Enums;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;
using static CameraBazaar.Models.Constants.ValidationMessages;


namespace CameraBazaar.Models.EntityModels
{
    public class Camera
    {
        public int Id { get; set; }

        [Required]
        public Make Make { get; set; }

        [Required, RegularExpression(CameraModelRegex, ErrorMessage = CameraModelValidationMessage)]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, Range(0, 100)]
        public int Quantity { get; set; }

        [Required, Range(0, 30)]
        public int MinShutterSpeed { get; set; }

        [Required, Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [Required, MinIso]
        public int MinIso { get; set; }

        [Required, Range(200, 409600), MaxIso]
        public int MaxIso { get; set; }

        public bool IsFullFrame { get; set; }

        [Required, StringLength(15)]
        public string VdeoResolution { get; set; }

        public LightMetering LightMetering { get; set; }

        [StringLength(6000)]
        public string Description { get; set; }

        [RegularExpression(ImageUrlRegex, ErrorMessage = ImageUrlMessage)]
        public string ImageUrl { get; set; }
    }
}