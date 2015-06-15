using System;
using System.Runtime.InteropServices;
using BankofKK.Models;

namespace BankofKK
{
    class BankofKK
    {
        private static void Main()
        {
            try
            {
                Deposit ivanDep = new Deposit(new Customer("Ivan", TypeCustomer.Individual, 3), 200m, 0.04m);
                ivanDep.DepositMoney(4000m);
                Console.WriteLine(ivanDep);
                ivanDep.CalcInterest(12);
                Console.WriteLine(ivanDep);
                ivanDep.WithdrawMoney(2000m);
                Console.WriteLine(ivanDep);
                //ivanDep.WithdrawMoney(6000m);
                //Console.WriteLine(ivanDep);

                Loan peshoLoan = new Loan(new Customer("Pecho",TypeCustomer.Company, 2), -30000m,0.07m);
                peshoLoan.DepositMoney(2000m);
                peshoLoan.CalcInterest(12);
                Console.WriteLine(peshoLoan);

              //  Loan pesho1Loan = new Loan(new Customer("Pecho", TypeCustomer.Company, 2), 30000m, 0.07m);

                Mortgage geryMortgage = new Mortgage(new Customer("Gery", TypeCustomer.Individual, 6), -25000m, 0.07m);
                Mortgage firmMortgage = new Mortgage(new Customer("Firmata", TypeCustomer.Company, 12), -250000m, 0.05m);
                geryMortgage.CalcInterest(12);
                firmMortgage.CalcInterest(12);
                Console.WriteLine(geryMortgage);
                Console.WriteLine(firmMortgage);

             //   Mortgage firm1Mortgage = new Mortgage(new Customer("Firmata", TypeCustomer.Company, 12), 250000m, 0.05m);
                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
