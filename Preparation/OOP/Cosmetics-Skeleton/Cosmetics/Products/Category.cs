using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private const int MinCatLenght = 2;
        private const int MaxCatLenght = 15;

        private string _name;
        private IList<IProduct> _products; 


        public Category(string name)
        {
            this.Name = name;
            this._products = new List<IProduct>();
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value,String.Format( GlobalErrorMessages.StringCannotBeNullOrEmpty,"Category name"));

                Validator.CheckIfStringLengthIsValid(value, MaxCatLenght, MinCatLenght,
                    String.Format(GlobalErrorMessages.InvalidStringLength, "Category name", MinCatLenght,
                        MaxCatLenght));
              
                this._name = value;
            }

        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this._products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this._products.Contains(cosmetics))
            {
                throw new ArithmeticException(String.Format( "Product {0} does not exist in category {1}",cosmetics.Name,this.Name));
            }
            this._products.Remove(cosmetics);
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} category – {1} product{2} in total",this.Name, this._products.Count,this._products.Count == 1 ? string.Empty : "s" );

            var sortedProd = this._products.OrderBy(x => x.Brand).ThenByDescending(y => y.Price);

            foreach (var product in sortedProd)
            {
                sb.AppendLine(product.Print());
            }
            return sb.ToString();
        }
    }
}