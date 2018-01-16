using System.Collections.Generic;
using System.ComponentModel;
using CarDealer.Models.ViewModels.Part;

namespace CarDealer.Models.ViewModels.Car
{
    public class CarAddVm
    {
        public CarAddVm()
        {
            this.Parts = new HashSet<PartForCarModel>();
        }

        [DisplayName("Make: ")]
        public string Make { get; set; }

        [DisplayName("Model: ")]
        public string Model { get; set; }

        [DisplayName("Travelled Distance: ")]
        public long TravelledDistance { get; set; }

        [DisplayName("Parts: ")]
        public ICollection<PartForCarModel> Parts { get; set; }
    }
}