using System;

namespace CountrySS
{
    class CountrySS
    {
        static void Main()
        {
            Country bg = new Country("Bulgaria", 7100000, 111000, "Sofia", "Plovdiv", "Varna");
            Country usa = new Country("USA", 300000000, 1200000, "New York", "Los Angeles", "San Francisco");
            Country bg2 = new Country("Bulgaria", 8000000, 10);
            Country bg3 = new Country("Bulgaria", 8000000, 111000);
            Country hr = new Country("Croatia", 8000000, 111000);

            Console.WriteLine(bg == bg2); // True
            Console.WriteLine(bg == usa); // False
            Console.WriteLine(bg != bg2); // False
            Console.WriteLine(bg != usa); // True


        }
    }
}
