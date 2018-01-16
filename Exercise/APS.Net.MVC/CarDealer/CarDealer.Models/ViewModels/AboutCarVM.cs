using System.Collections.Generic;
using CarDealer.Models.EntityModels;

namespace CarDealer.Models.ViewModels
{
    public class AboutCarVM
    {
        public CarsByMakeVM Car { get; set; }

        public IEnumerable<PartsVM> Parts { get; set; }
    }
}