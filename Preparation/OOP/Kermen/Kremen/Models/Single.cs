namespace Kremen.Models
{
    public class Single : HouseHold
    {
        public Single(decimal income, int numberOfRooms, decimal roomElectricity)
            : base(income, numberOfRooms, roomElectricity)
        {
        }
    }
}
