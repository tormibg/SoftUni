namespace CarDealer.Models.ViewModels.Sale
{
    public class SaleAddConfirmationVM
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int CarId { get; set; }

        public string CarName { get; set; }

        public decimal Discount { get; set; }

        public decimal CarPrice { get; set; }

        public decimal CarFinalPrice { get; set; }
    }
}