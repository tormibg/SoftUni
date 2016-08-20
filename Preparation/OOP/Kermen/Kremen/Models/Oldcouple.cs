namespace Kremen.Models
{
    class OldCouple : Couple
    {
        private const int NumberOfRooms = 3;
        private const decimal RoomElectricity = 15;

        private decimal stoveCost;

        public OldCouple(decimal pensionOne, decimal pensioTwo, decimal tvCost, decimal fridgeCost, decimal stoveCost) 
            : base(NumberOfRooms, RoomElectricity, pensionOne + pensioTwo, tvCost, fridgeCost)
        {
            this.stoveCost = stoveCost;
        }

        public override decimal Consumation
        {
            get
            {
                return this.stoveCost + base.Consumation;
            }
        }
    }
}
