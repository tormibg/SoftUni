using HotelDatabase.Models;

namespace HotelDatabase
{
    using System.Data.Entity;

    public class HotelContext : DbContext
    {
        public HotelContext()
            : base("name=HotelContext")
        {
        }

        public IDbSet<BedType> BedTypes { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Occupancy> Occupancies { get; set; }
        public IDbSet<Payment> Payments { get; set; }
        public IDbSet<Room> Rooms { get; set; }
        public IDbSet<RoomStatus> RoomStatuses { get; set; }
        public IDbSet<RoomType> RoomTypes { get; set; }
    }
}