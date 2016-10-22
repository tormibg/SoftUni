namespace Kremen.Models
{
    public abstract class Couple : HouseHold
    {
        private decimal tvCost;
        private decimal fridgeCost;

        public Couple(int numberOfRooms, decimal roomElectricity, decimal income, decimal tvCost, decimal fridgeCost)
            : base(income, numberOfRooms, roomElectricity)
        {
            this.tvCost = tvCost;
            this.fridgeCost = fridgeCost;
        }

        public override decimal Consumation
        {
            get
            {
                return this.tvCost + this.fridgeCost + base.Consumation;
            }
        }

        public override int Population
        {
            get
            {
                return base.Population + 1;
            }
        }
    }
}