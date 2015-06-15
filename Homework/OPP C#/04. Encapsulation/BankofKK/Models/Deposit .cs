using System;

namespace BankofKK.Models
{
    public class Deposit : Account
    {
  
        public Deposit(Customer customer, decimal balance, decimal intRate):base(customer,balance,intRate)
        {
          
        }
 
        public override void CalcInterest(int period)
        {
            if (this.Balance < 1000 )
            {
                return;
            }
            this.Balance = this.Balance * (1 + this.InterestRate * period);
        }

        public void WithdrawMoney(decimal money)
        {
            if (money > this.Balance)
            {
                throw new ArgumentOutOfRangeException("money","Sorry not enough  money.");
            }
            this.Balance -= money;
        }

    }
}