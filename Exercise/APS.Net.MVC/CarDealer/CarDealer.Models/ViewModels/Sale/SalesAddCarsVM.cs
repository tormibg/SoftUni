using System.ComponentModel;

namespace CarDealer.Models.ViewModels.Sale
{
    public class SalesAddCarsVM
    {
        public int Id { get; set; }

        [DisplayName("Car: ")]
        public string MakeAndModel { get; set; }
    }
}