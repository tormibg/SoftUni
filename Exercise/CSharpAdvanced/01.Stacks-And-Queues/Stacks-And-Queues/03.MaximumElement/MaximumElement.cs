namespace _03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main()
        {
            Stack<uint> stack = new Stack<uint>();
            Stack<uint> maxStack = new Stack<uint>();
            maxStack.Push(uint.MinValue);

            uint lineNum = uint.Parse(Console.ReadLine());
            for (int i = 0; i < lineNum; i++)
            {
                uint[] input =
                    Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(uint.Parse)
                        .ToArray();

                switch (input[0])
                {
                    case 1:
                        PushElement(input[1], stack, maxStack);
                        break;
                    case 2:
                        DeleteElement(stack, maxStack);
                        break;
                    case 3:
                        PrintMaxElement(maxStack);
                        break;
                }
            }
        }

        private static void PrintMaxElement(Stack<uint> maxStack)
        {
            Console.WriteLine(maxStack.Peek());
        }

        private static void DeleteElement(Stack<uint> stack, Stack<uint> maxStack)
        {
            uint u = stack.Pop();
            if (u == maxStack.Peek())
            {
                maxStack.Pop();
            }
        }

        private static void PushElement(uint u, Stack<uint> stack, Stack<uint> maxStack)
        {
            stack.Push(u);
            if (u > maxStack.Peek())
            {
                maxStack.Push(u);
            }
        }
    }
}
