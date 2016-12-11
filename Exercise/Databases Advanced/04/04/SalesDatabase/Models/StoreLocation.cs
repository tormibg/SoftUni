using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesDatabase.Models
{
    public class StoreLocation
    {
        public StoreLocation()
        {
            this.Sales = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string LocationName { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}