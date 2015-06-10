using System;

namespace BookShop
{
    class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public virtual decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                   throw new ArgumentException("Price must be > 0");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            string result = String.Format("{0}, {1}, {2}", this.Title, this.Author, this.Price);
            return result;
        }
    }
}
