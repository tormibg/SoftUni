using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using CreateUser.Attributes;

namespace CreateUser.Models
{
    public class User
    {
        public User()
        {
            this.Friends = new HashSet<User>();
            this.UserAlbums = new HashSet<UserAlbum>();
        }

        [Key, Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required, MinLength(4), MaxLength(30)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(50),
         Password(6, 50, ShouldContainAtLeastOneLowerCaseLetter = true, ShouldContainAtLeastOneUpperCaseLetter = true,
             ShouldContainAtLeastOneDigit = true, ShouldContainAtLeastOneSpecialSimbol = true)]
        public string Password { get; set; }

        [Required, Email]
        public string Email { get; set; }

        [MaxLength(1024 * 2014)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public Town TownInBorn { get; set; }

        public Town TownInLiving { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        public virtual ICollection<UserAlbum> UserAlbums { get; set; }

        [NotMapped]
        public string FullName => this.FirstName + " " + this.LastName;

        [NotMapped]
        public Image MyImage
        {
            get
            {
                //byte[] result;
                //using (MemoryStream ms = new MemoryStream(this.ProfilePicture))
                //{
                //    MyImage.Save(ms,ImageFormat.Jpeg);
                //    result = ms.ToArray();
                //}
                //return result;

                MemoryStream ms = new MemoryStream(this.ProfilePicture);

                foreach (var chunk in this.ProfilePicture)
                {
                    ms.WriteByte(chunk);
                }

                return Image.FromStream(ms);
            }
        }
    }
}