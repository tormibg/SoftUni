﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CreateUser.Attributes;

namespace CreateUser.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        [Required, Tag]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}