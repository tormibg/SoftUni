namespace Kremen.Models
{
    using System.Linq;

    public class Child
    {
        private decimal[] consumptions;

        public Child(decimal[] consumptions)
        {
            this.consumptions = consumptions;
        }

        public decimal GetTotalConsumption()
        {
            return this.consumptions.Sum();
        }
    }
}