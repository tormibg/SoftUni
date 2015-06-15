using System;

namespace BankofKK.Models
{
    public class Mortgage : Account
    {
        

        public Mortgage(Customer customer, decimal balance, decimal intRate)
            : base(customer,balance,  intRate)
        {
            
        }
        
        public override void CalcInterest(int period)
        {
            if (period <= this.Customer.FreeInt)
            {
                if (this.Customer.Type == TypeCustomer.Individual)
                {
                    return;
                }
                else
                {
                    this.Balance += (this.Balance*(1 + this.InterestRate*period))*0.5m;
                }

            }
            else
            {
                if (this.Customer.Type == TypeCustomer.Company)
                {
                    this.Balance += (this.Balance * (1 + this.InterestRate * this.Customer.FreeInt))*0.5m;   
                }
                this.Balance += (this.Balance * (1 + this.InterestRate * (period - this.Customer.FreeInt)));
            }
        }
    }
}