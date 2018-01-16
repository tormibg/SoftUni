using System.Collections.Generic;
using System.ComponentModel;
using CarDealer.Models.ViewModels.Supplier;

namespace CarDealer.Models.ViewModels.Part
{
    public class PartAddVm
    {
        public PartAddVm()
        {
            this.SupplierAddPartVms = new List<AddSupplierVM>();    
        }

        [DisplayName("Name: ")]
        public string Name { get; set; }

        [DisplayName("Price: ")]
        public decimal Price  { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Supplier")]
        public IEnumerable<AddSupplierVM> SupplierAddPartVms { get; set; }
    }
}