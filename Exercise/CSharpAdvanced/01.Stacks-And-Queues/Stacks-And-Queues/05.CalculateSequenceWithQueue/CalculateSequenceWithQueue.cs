namespace _05.CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CalculateSequenceWithQueue
    {
        public static void Main()
        {
            long inputInt = long.Parse(Console.ReadLine().Trim());
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(inputInt);

            for (int i = 0; i < 50; i++)
            {
                long current = queue.Dequeue();
                Console.Write($"{current} ");

                long s2 = current + 1;
                long s3 = 2 * current + 1;
                long s4 = current + 2;


                queue.Enqueue(s2);

                queue.Enqueue(s3);

                queue.Enqueue(s4);

            }
        }
    }
}
