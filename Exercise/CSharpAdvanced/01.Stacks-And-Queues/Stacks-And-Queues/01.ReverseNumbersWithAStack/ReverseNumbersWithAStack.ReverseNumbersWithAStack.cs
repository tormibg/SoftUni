namespace _01.ReverseNumbersWithAStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbersWithAStack
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            if (input != null)
            {
                int[] numInts =
                    input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                Stack<int> stackInt = new Stack<int>();

                foreach (int i in numInts)
                {
                    stackInt.Push(i);
                }

                Console.WriteLine(String.Join(" ", stackInt));
            }
        }
    }
}
