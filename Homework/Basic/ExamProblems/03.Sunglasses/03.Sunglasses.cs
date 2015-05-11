using System;

class Sunglasses
{
    static void Main()
    {
        int iNum = 0;
        iNum = int.Parse(Console.ReadLine());
        for (int i = 0; i < iNum; i++)
        {
            if (i == 0 || i == iNum - 1)
            {
                Console.WriteLine("{0}{1}{0}", new string('*', iNum * 2), new string(' ', iNum));
            }
            else if (i == iNum / 2)
            {
                Console.WriteLine("*{0}*{1}*{0}*", new string('/', (iNum * 2) - 2), new string('|', iNum));
            }
            else
            {

                Console.WriteLine("*{0}*{1}*{0}*", new string('/', (iNum * 2) - 2), new string(' ', iNum));
            }
        }
    }
}