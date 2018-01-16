using System.Collections.Generic;
using CarDealer.Models.EntityModels;
using CarDealer.Models.ViewModels.Part;

namespace CarDealer.Models.ViewModels.Supplier
{
    public class AllSupplierVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PartForCarModel> Parts { get; set; }
    }
}