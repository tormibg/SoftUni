using System;

class Beer
{
    private static void Main()
    {
        int iBeers = 0;
        string sCommand = Console.ReadLine();
        while (sCommand != "End")
        {
            string[] aBeerStrings = sCommand.Split();
            if (sCommand.Contains("stacks"))
            {
                iBeers += 20*int.Parse(aBeerStrings[0]);
            }
            else if (sCommand.Contains("beers"))
            {
                iBeers += int.Parse(aBeerStrings[0]);
            }
            sCommand = Console.ReadLine();
        }
        Console.WriteLine("{0} stacks + {1} beers ",iBeers / 20, iBeers % 20);
    }
}