namespace Kremen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kremen.Factories;
    using Kremen.Models;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<HouseHold> kermen = new List<HouseHold>();
            int couter = 0;

            while (input != "Democracy")
            {
                couter++;
                try
                {
                    HouseHold entry = HouseHoldFactory.CreateHouseHold(input);
                    kermen.Add(entry);
                }
                catch (Exception)
                {

                }
                if (couter % 3 == 0)
                {
                    kermen.ForEach(x => x.GetIncome());
                }
                if (input == "EVN bill")
                {
                    kermen.RemoveAll(x => !x.CanPayBill());
                    kermen.ForEach(x => x.PayBills());

//                    foreach (var houseHold in kermen)
//                    {
//                        if (houseHold.CanPayBill())
//                        {
//                            houseHold.PayBills();
//                        }
//                    }
                }
                else if (input == "EVN")
                {
                    Console.WriteLine($"Total population: {kermen.Sum(x => x.Consumation)}");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total population: {kermen.Sum(x => x.Population)}");
        }
    }
}
