namespace Kremen.Models
{
    public abstract class HouseHold
    {
        private int numberOfRooms;
        private decimal roomElectricity;
        private readonly decimal income;
        private decimal money;

        protected HouseHold(decimal income, int numberOfRooms, decimal roomElectricity)
        {
            this.numberOfRooms = numberOfRooms;
            this.roomElectricity = roomElectricity;
            this.income = income;
            this.money = 0;
        }

        public virtual int Population
        {
            get
            {
                return 1;
            }
        }

        public virtual decimal Consumation
        {
            get
            {
                return this.roomElectricity * this.numberOfRooms;
            }
        }

        public void GetIncome()
        {
            this.money += this.income;
        }

        public bool CanPayBill()
        {
            return this.money >= this.Consumation;
        }

        public void PayBills()
        {
            this.money -= this.Consumation;
        }
    }
}