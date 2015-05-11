using System;
using System.Linq;

class MinMaxSumAverage
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint iNum;
            Console.Write("Enter numbers :");
            if (uint.TryParse(Console.ReadLine(), out iNum))
            {
                int[] aNum = new int[iNum];
                for (int i = 0; i < iNum; i++)
                {
                    while (true)
                    {
                        Console.Write("Enter the {0} number : ", i + 1);
                        if (int.TryParse(Console.ReadLine(), out aNum[i]))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Only integer number.");
                        }
                    }
                }
                Console.WriteLine("min = {0}",aNum.Min());
                Console.WriteLine("max = {0}",aNum.Max());
                Console.WriteLine("sum = {0}",aNum.Sum());
                Console.WriteLine("avg = {0}",aNum.Average().ToString("F"));
            }
            else
            {
                Console.WriteLine("Only positive integer number.");
            }
        }
    }
}