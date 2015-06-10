namespace Company.Interfaces
{
    public interface ICustomer
    {
        decimal PurchAmount { get; set; }

        void AddPurchasePrice(decimal purchasePrice);

        string ToString();
    }
}