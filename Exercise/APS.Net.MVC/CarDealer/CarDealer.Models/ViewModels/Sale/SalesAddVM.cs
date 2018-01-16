using System.Collections.Generic;
using System.ComponentModel;
using CarDealer.Models.EntityModels;

namespace CarDealer.Models.ViewModels.Sale
{
    public class SalesAddVM
    {
        [DisplayName("Customer: ")]
        public IEnumerable<SalesAddCustomersVM> CustomersId { get; set; }

        [DisplayName("Cars: ")]
        public IEnumerable<SalesAddCarsVM> CarsId { get; set; }

        [DisplayName("Discount%: ")]
        public IEnumerable<int> Discounts { get; set; }
    }
}