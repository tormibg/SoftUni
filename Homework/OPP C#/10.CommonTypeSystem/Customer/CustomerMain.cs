using System;
using System.Collections.Generic;

namespace Customer
{
    class CustomerMain
    {
        static void Main()
        {
            Customer cust1 = new Customer("Todor", "Todorov", "Todorov", "7712123456", "Lunapark 12", "0888987654", "todor@gmail.com", CustomerType.Golden, new List<Payment>() {
                new Payment("abv", 120.3m),
                new Payment("gbh", 543.51m),
                new Payment("qazs", 34.21m)
            });

            Customer cust2 = new Customer("Todor", "Todorov", "Todorov", "7712123456", "Lunapark 12", "0888987654", "todor@gmail.com", CustomerType.Golden, new List<Payment>() {
                new Payment("abv", 120.3m),
                new Payment("gbh", 543.51m),
                new Payment("qazs", 34.21m)
            });

            Customer cust3 = new Customer("Ivan", "Ivanov", "Ivanov", "7854872345", "lozenec 52", "0987444543", "ivan@gmail.com", CustomerType.Regular, new List<Payment>() {
                new Payment("HIFI", 132.3m),
                new Payment("DVD", 322.5m),
                new Payment("TV", 75.2m)
            });

            Console.WriteLine(cust1);

            Console.WriteLine();

            Console.WriteLine(cust1.Equals(cust2));
            Console.WriteLine(cust1 == cust3);
            Console.WriteLine(cust1 != cust3);
            Console.WriteLine(cust1.CompareTo(cust2));

            Customer newCust = (Customer)cust1.Clone();
            Console.WriteLine(newCust.FirstName);
            newCust.FirstName = "Cloniran";
            Console.WriteLine(newCust.FirstName);
            Console.WriteLine(cust1.FirstName);

        }
    }
}
