namespace Kremen.Models
{
    public class AlongYoung : Single
    {
        private const int NumberOfRooms = 1;
        private const decimal RoomElectricity = 10;

        private decimal laptopCost;

        public AlongYoung(decimal income, decimal laptopCost)
            : base(income, NumberOfRooms, RoomElectricity)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumation
        {
            get
            {
                return this.laptopCost + base.Consumation;
            }
        }
    }
}
