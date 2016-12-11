using BillsPaymentModels;

namespace BillsPaymentData
{
    using System.Data.Entity;

    public class BillsPaymentContextTph : DbContext
    {
        public BillsPaymentContextTph()
            : base("name=BillsPaymentContext")
        {
        }
        public IDbSet<User> Users { get; set; }
        public IDbSet<BillingDetail> BillingDetails { get; set; }
    }

}