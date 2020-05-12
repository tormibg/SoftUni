using System;
using System.ComponentModel.DataAnnotations;

namespace Andreys.App.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required, MaxLength(10)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}