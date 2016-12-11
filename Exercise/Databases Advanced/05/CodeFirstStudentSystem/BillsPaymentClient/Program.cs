using BillsPaymentData;

namespace BillsPaymentClient
{
    class Program
    {
        static void Main()
        {
            var context = new BillsPaymentContextTpt();
            context.Database.Initialize(true);
        }
    }
}
