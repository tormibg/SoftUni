﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDatabase.Models
{
    public class Doctor
    {

        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; }
    }
}