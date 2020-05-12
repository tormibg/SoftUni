using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    public class Tweet
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        [Required]
        public string Creator { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
