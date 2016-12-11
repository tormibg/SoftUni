using System.ComponentModel.DataAnnotations;

namespace HotelDatabase.Models
{
    public class RoomType
    {
        public enum RoomTypes
        {
            Small, Medium, Large
        }

        [Key]
        public RoomTypes Type { get; set; }

        public string Notes { get; set; }
    }
}