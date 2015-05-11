using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

class OddAndEvenProduct
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int oddNum = 1, evenNum = 1;
            Console.Write("Enter integer number /single line, separated by a space/ : ");
            string sN = Console.ReadLine();
            string[] asN = sN.Split(' ');
            for (int i = 1; i <= asN.Length; i++)
            {
                int iNumber = int.Parse(asN[i-1]);
                if (i % 2 != 0)
                {
                    oddNum *= iNumber;
                }
                else
                {
                    evenNum *= iNumber;
                }
            }
            if (oddNum == evenNum)
            {
                Console.WriteLine("yes");
                Console.WriteLine("product = {0}",oddNum);
            }
            else
            {
                Console.WriteLine("no");
                Console.WriteLine("odd_product = {0}",oddNum);
                Console.WriteLine("even_product = {0}",evenNum);
            }
        }
    }
}
