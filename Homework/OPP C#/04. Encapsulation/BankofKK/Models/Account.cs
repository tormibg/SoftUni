using System;
using BankofKK.Interface;

namespace BankofKK.Models
{
    public abstract class Account : IAccount
    {
        protected Account(Customer customer, decimal balance, decimal intRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = intRate;
        }

        public Customer Customer { get; set; }

        public decimal Balance { get; set; }

        public decimal InterestRate { get; set; }

        public void DepositMoney(decimal money)
        {
            this.Balance += money;
        }

        public abstract void CalcInterest(int period);
        public override string ToString()
        {
            string retStr = String.Format("Name - {0}, Balance : {1}",this.Customer.Name,this.Balance);
            return retStr;
        }
    }
}