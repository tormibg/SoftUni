namespace _02.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int[] commandsInts =
                input?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            input = Console.ReadLine();
            int[] inputInts =
                input?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int maxCount = inputInts.Length;

            Stack<int> inputStack = new Stack<int>();
            for (int i = 0; i <= commandsInts[0] && i < maxCount; i++)
            {
                inputStack.Push(inputInts[i]);
            }

            maxCount = inputStack.Count;

            for (int i = 0; i < commandsInts[1] && i < maxCount; i++)
            {
                inputStack.Pop();
            }

            /*Console.WriteLine(String.Join(" ", inputStack));*/

            if (inputStack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (inputStack.Contains(commandsInts[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallInt = Int32.MaxValue;
                foreach (int i in inputStack)
                {
                    if (i < smallInt)
                    {
                        smallInt = i;
                    }
                }
                Console.WriteLine($"{smallInt}");
            }
        }
    }
}