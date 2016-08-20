namespace Kremen.Models
{
    internal class AloneOld : Single
    {
        private const int NumberOfRooms = 1;
        private const decimal RoomElectricity = 15;

        public AloneOld(decimal pension)
            : base(pension, NumberOfRooms, RoomElectricity)
        {
        }
    }
}
