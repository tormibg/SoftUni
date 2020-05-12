using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlusApp.Models
{
    public class Problems
    {
        public Problems()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submissions>();
        }
        public string Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public int Points { get; set; }

        public ICollection<Submissions> Submissions { get; set; }

    }
}
