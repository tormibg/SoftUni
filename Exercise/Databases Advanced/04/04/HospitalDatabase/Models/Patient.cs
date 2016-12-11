using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDatabase.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Diagnoses = new HashSet<Diagnose>();
            this.Visitations = new HashSet<Visitation>();
            this.Medicaments = new HashSet<Medicament>();
        }

        [Key, Range(1, int.MaxValue)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte[] Picture { get; set; }

        public bool IsInsure { get; set; }

        public ICollection<Visitation> Visitations { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }

        public ICollection<Medicament> Medicaments { get; set; }
    }
}