using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesDatabase.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal Quantity { get; set; }

        [Range(typeof(decimal), "0", "10000000000")]
        public decimal Price { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}