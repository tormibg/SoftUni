using System;

class RandomNumbersInGivenRange
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iN, iMin, iMax;
            Console.Write("Enter n /integer/ : ");
            var sN = Console.ReadLine();
            Console.Write("Enter min /integer/ : ");
            var sMin = Console.ReadLine();
            Console.Write("Enter max /integer/ : ");
            var sMax = Console.ReadLine();
            if (int.TryParse(sMin, out iMin) && int.TryParse(sMax, out iMax) && int.TryParse(sN, out iN) && iMax >= iMin)
            {
                Random rnd = new Random();
                Console.Write("Random numbers : ");
                for (int i = 0; i < iN; i++)
                {
                    int iResult = rnd.Next(iMin, iMax+1);
                    Console.Write("{0} ",iResult);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Onli integer numbers and max >= min.");
            }
        }
    }
}