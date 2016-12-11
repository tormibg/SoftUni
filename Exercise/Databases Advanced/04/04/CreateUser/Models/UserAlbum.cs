using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreateUser.Models
{
    public class UserAlbum
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Key, Column(Order = 1)]
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

        public string UserRole { get; set; }
    }
}