using System;

namespace LaptopShop
{
    class Program
    {
        static void Main()
        {
            Laptop newLaptop = new Laptop("HP 250 G2", 699.00m);
            Console.WriteLine(newLaptop.Model + " "+ newLaptop.Price);
            Console.WriteLine(newLaptop);
            newLaptop.RAM = 12;
            newLaptop.Processor = "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)";
            Console.WriteLine(newLaptop);
            newLaptop.LapBattery = new Battery("Li-Ion, 4-cells, 2550 mAh", 4.5f);

        }
    }
}
