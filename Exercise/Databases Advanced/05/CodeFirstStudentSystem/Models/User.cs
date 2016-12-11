using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentModels
{
    public class User
    {
        public User()
        {
            this.BillingDetails = new HashSet<BillingDetail>();
        }
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<BillingDetail> BillingDetails { get; set; }
    }
}
