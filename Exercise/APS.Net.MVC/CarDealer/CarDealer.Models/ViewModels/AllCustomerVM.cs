using System;

namespace CarDealer.Models.ViewModels
{
    public class AllCustomerVM
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }
    }
}