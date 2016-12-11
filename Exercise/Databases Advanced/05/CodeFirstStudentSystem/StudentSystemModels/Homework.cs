using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystemModels
{
    public class Homework
    {
        public enum ContentOfType
        {
            Application,
            Pdf,
            Zip
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentOfType ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}