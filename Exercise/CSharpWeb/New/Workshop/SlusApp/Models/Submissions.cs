using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlusApp.Models
{
    public class Submissions
    {
        public Submissions()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required, MaxLength(800)]
        public string Code { get; set; }

        public int AchievedResult  { get; set; }
        [Required]
        public DateTime CreatedOn  { get; set; }
        public string ProblemsId { get; set; }
        public virtual Problems Problems { get; set; }
        public string UserssId { get; set; }
        public virtual User Users { get; set; }
    }
}
