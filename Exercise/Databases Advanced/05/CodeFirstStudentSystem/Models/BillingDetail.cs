using System.ComponentModel.DataAnnotations;

namespace BillsPaymentModels
{
    public class BillingDetail
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public User Owner { get; set; }
    }
}