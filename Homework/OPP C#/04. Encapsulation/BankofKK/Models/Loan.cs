using System;

namespace BankofKK.Models
{
    public class Loan : Account
    {
        

        public Loan(Customer customer, decimal balance, decimal intRate)
            : base(customer, balance, intRate)
        {
            
        }

     
        public override void CalcInterest(int period)
        {
            if (period<= this.Customer.FreeInt)
            {
                return;
            }
            this.Balance += this.Balance*(1 + this.InterestRate*(period-this.Customer.FreeInt));
        }
    }
}