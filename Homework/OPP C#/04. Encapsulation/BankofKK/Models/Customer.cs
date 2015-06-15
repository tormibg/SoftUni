namespace BankofKK.Models
{
    public class Customer
    {
        public Customer(string name, TypeCustomer type, int freeInt)
        {
            this.Name = name;
            this.Type = type;
            this.FreeInt = freeInt;
        }
        public string Name { get; set; }
        public TypeCustomer Type { get; private set; }
        public int FreeInt { get; set; }
    }
}