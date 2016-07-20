namespace _04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            int[] inputCommandsInts =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int[] inputInts =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < inputCommandsInts[0] && i < inputInts.Length; i++)
            {
                queue.Enqueue(inputInts[i]);
            }

            int maxCount = queue.Count;

            for (int i = 0; i < inputCommandsInts[1] && i < maxCount; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (queue.Contains(inputCommandsInts[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                int minValue = int.MaxValue;
                foreach (int i in queue)
                {
                    if (i < minValue)
                    {
                        minValue = i;
                    }
                }
                Console.WriteLine(minValue);
            }
        }
    }
}
