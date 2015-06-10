using System;
using Company.Interfaces;

namespace Company.Models
{
    class Customer : Person, ICustomer
    {
       // private decimal purchAmount;

        public Customer(string id, string firsName, string lastName, decimal purchAmount ) : base(id, firsName, lastName)
        {
            this.PurchAmount = purchAmount;
        }

        public decimal PurchAmount { get; set; }

        public override string ToString()
        {
            string retStr = String.Format("ID - {0}, Name - {1} {2}, PurchAmount - {3}"
                                        , this.Id, this.FirstName, this.LastName, this.PurchAmount);
            return retStr;
        }

        public void AddPurchasePrice(decimal purchasePrice)
        {
            PurchAmount += purchasePrice;
        }
    }
}
