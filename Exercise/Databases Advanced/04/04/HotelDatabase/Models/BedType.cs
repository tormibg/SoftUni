using System.ComponentModel.DataAnnotations;

namespace HotelDatabase.Models
{
    public class BedType
    {
        public enum BedTypes
        {
            KingSize, Small, Large, Medium
        }

        [Key]
        public BedTypes Type { get; set; }

        public string Notes { get; set; }
    }
}