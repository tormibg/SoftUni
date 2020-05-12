using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Work.MVC;

namespace SlusApp.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submissions>();
        }

        public ICollection<Submissions> Submissions { get; set; }
    }
}
