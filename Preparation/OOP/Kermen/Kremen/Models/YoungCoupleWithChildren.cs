namespace Kremen.Models
{
    using System.Linq;

    public class YoungCoupleWithChildren : YoungCouple
    {
        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 30;

        private Child[] children;

        public YoungCoupleWithChildren(decimal salaryOne, decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost, Child[] children)
            : base(NumberOfRooms, RoomElectricity, salaryOne + salaryTwo, tvCost, fridgeCost, laptopCost)
        {
            this.children = children;
        }

        public override decimal Consumation
        {
            get
            {
                return this.children.Sum(x => x.GetTotalConsumption()) + base.Consumation;
            }
        }
        public override int Population
        {
            get
            {
                return this.children.Length + base.Population;
            }
        }
    }
}