using System.ComponentModel.DataAnnotations;

namespace HotelDatabase.Models
{
    public class RoomStatus
    {
        public enum RoomStatuses
        {
            Occupied, Free, BeingCleaned
        }

        [Key]
        public RoomStatuses Status { get; set; }

        public string Notes { get; set; }
    }
}