using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniStore.App.Model
{
    public class User
    {

        public User()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        //public string Username { get; set; }

        //[Index("Email",IsUnique = true)]
        //[StringLength(450)]
        public string Email { get; set; }

        //[RegularExpression(@"^\d{4}$")]
        //[Column(TypeName = "char")]
        //[StringLength(4)]
        public string Password { get; set; }

        public string Fullname { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
