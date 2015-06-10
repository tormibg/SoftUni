using System;
using System.Collections.Generic;

namespace PCCatalog
{
    class PCCatalog
    {
        static void Main()
        {
            // описанията са взети назаем, както и toString метода.

            var catalog = new List<Computer>();

            var componentsList1 = new List<Component>();
            componentsList1.Add(new Component("Motherboard", 90));
            componentsList1.Add(new Component("CPU", 120.45m));
            componentsList1.Add(new Component("RAM", 45.50m, "8 GB"));

            var pc = new Computer("HP", componentsList1);
            Console.WriteLine(pc);
            pc.AddComponent(new Component("added later", 126));
            Console.WriteLine(pc);

            catalog.Add(pc);

            var componentsList2 = new List<Component>();
            componentsList2.Add(new Component("DVD", 15.99m));
            componentsList2.Add(new Component("GPU", 255.1m));

            catalog.Add(new Computer("Cheap", componentsList2));

            var componentsList3 = new List<Component>();
            componentsList3.Add(new Component("RAM", 52.19m));
            componentsList3.Add(new Component("SSD", 550));

            catalog.Add(new Computer("Average", componentsList3));

            var componentsList4 = new List<Component>();
            componentsList4.Add(new Component("GPU", 1125.5m));
            componentsList4.Add(new Component("CPU", 900));

            catalog.Add(new Computer("Expensive", componentsList4));


            catalog.Sort();
            Console.WriteLine("\r\n" + new string('-', 50) + "\r\n" + "COMPUTER CATALOG");
            foreach (var computer in catalog)
            {
                Console.WriteLine(computer);
            }
        }
    }
}
