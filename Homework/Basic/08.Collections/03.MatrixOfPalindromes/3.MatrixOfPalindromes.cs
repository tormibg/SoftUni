using System;
using System.Runtime.Serialization.Formatters;

class MatrixOfPalindromes
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.Write("How many rows : ");
            uint uiRow = uint.Parse(Console.ReadLine());
            Console.Write("How many columns : ");
            uint uiCol = uint.Parse(Console.ReadLine());
            char cFirstCh = '\u0061';
            for (int i = 0; i < uiRow; i++)
            {
                for (int j = 0; j < uiCol; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("{0}{1}{2} ",(char)(cFirstCh + i),(char)(cFirstCh + i),(char)(cFirstCh + i));
                    }
                    else
                    {
                        Console.Write("{0}{1}{2} ", (char)(cFirstCh + i), (char)(cFirstCh + i + j), (char)(cFirstCh + i));
                    }
                }
                Console.WriteLine();
            }
        }
    }
}