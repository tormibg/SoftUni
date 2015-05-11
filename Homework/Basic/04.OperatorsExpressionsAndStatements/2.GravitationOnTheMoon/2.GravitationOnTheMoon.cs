using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            double ldWeight;
            Console.Write("Enter weight : ");
            if (double.TryParse(Console.ReadLine(), out ldWeight))
            {
                if (ldWeight > 0)
                {
                    Console.WriteLine("Weght on the Earth : {0}, but on the Moon : {1}", ldWeight, ldWeight * 17 / 100);
                }
                else
                {
                    Console.WriteLine("Seriously weight < 0 ?!");
                }
            }
            else
            {
                Console.WriteLine("Only real number");
            }
        }
    }
}