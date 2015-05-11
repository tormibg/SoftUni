using System;
using System.Linq;

class SortingNumbers
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.Write("How many numbers : ");
            uint uiNumber = uint.Parse(Console.ReadLine());
            int[] aNumbers = new int[uiNumber];
            for (int i = 0; i < uiNumber; i++)
            {
                Console.Write("Enter {0}-st number : ",i+1);
                aNumbers[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(aNumbers);
            for (int i = 0; i < uiNumber; i++)
            {
                Console.WriteLine(aNumbers[i]);
            }
        }
    }
}
