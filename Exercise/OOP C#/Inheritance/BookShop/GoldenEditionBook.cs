using System.Dynamic;

namespace BookShop
{
    class GoldenEditionBook : Book
    {
        private decimal price;
        private const decimal goldPirce =  1.30M;

        public GoldenEditionBook(string title, string author, decimal price) : base(title, author, price)
        {
            //this.Price = price;
        }

        public override decimal Price
        {
            // get { return this.price * goldPirce; }
            // set { this.price = value; }
            get { return base.Price * goldPirce; }
        }
        
    }
}
