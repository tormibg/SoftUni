using BankofKK.Models;

namespace BankofKK.Interface
{
    public interface IAccount
    {
        Customer Customer { get; set; }
       // decimal Balance { get; set; }
        decimal InterestRate { get; set; }
        void DepositMoney(decimal money);
        void CalcInterest(int period);
    }
}