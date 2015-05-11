using System;

class InsideTheBuilding
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[] aCord = new int[10];
        for (int i = 0; i < 10; i++)
        {
            aCord[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < 10; i += 2)
        {
            if (aCord[i] >= 0 && aCord[i] <= size*3 && aCord[i+1] >= 0 && aCord[i+1] <= size)
            {
                Console.WriteLine("inside");
            }
            else if (aCord[i] >= size && aCord[i] <= size * 2 && aCord[i + 1] >= size && aCord[i + 1] <= size * 4)
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}