 using System;

namespace StringDisperser
{
    class StringDisperserMain
    {
        static void Main()
        {
            StringDisperser sd1 = new StringDisperser("gosho", "pesho", "tanio");
            foreach (var ch in sd1)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();
            StringDisperser sd2 = new StringDisperser("test","first","testt");

            Console.WriteLine(sd1.Equals(sd2));
            StringDisperser newSD = (StringDisperser)sd1.Clone();

            Console.WriteLine(sd1 == newSD);
            Console.WriteLine(sd1 != sd2);

            newSD.Strings = "abv";

            Console.WriteLine(sd1.Strings);
            Console.WriteLine(newSD.Strings);

            Console.WriteLine(sd1);
        }
    }
}
