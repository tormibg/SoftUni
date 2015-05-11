using System;

class PrintASequence
{
    static void Main()
    {
        for (int i = 2; i <= 11; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(i);
            }
            else
            {
                Console.Write(i * -1);
            }
            if (i < 11)
            {
                Console.Write(",");
            }
         }
    }
}

