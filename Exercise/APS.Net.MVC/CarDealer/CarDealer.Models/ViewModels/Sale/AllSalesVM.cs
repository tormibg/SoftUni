namespace CarDealer.Models.ViewModels.Sale
{
    public class AllSalesVM
    {
        public CarsByMakeVM Car { get; set; }
        public AllCustomerVM Customer { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
    }
}