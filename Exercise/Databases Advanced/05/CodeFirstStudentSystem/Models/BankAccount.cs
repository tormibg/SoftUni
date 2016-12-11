namespace BillsPaymentModels
{
    public class BankAccount : BillingDetail
    {
        public string BankName { get; set; }

        public string SwiftCode { get; set; }
    }
}