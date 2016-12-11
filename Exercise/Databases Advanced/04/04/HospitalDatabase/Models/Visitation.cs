using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalDatabase.Models
{
    public class Visitation
    {
        [Key, Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [Required]
        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }
    }
}