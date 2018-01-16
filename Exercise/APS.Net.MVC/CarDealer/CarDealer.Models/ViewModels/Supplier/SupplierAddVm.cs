using System.ComponentModel;

namespace CarDealer.Models.ViewModels.Supplier
{
    public class SupplierAddVm
    {
        [DisplayName("Name: ")]
        public string Name { get; set; }
        [DisplayName("Is importer: ")]
        public bool isImporter { get; set; }
    }
}