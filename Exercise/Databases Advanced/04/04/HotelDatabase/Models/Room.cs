using System.ComponentModel.DataAnnotations;

namespace HotelDatabase.Models
{
    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        [Required]
        public BedType BedType { get; set; }

        public decimal Rate { get; set; }

        [Required]
        public RoomStatus RoomStatus { get; set; }

        public string Notes { get; set; }
    }
}