namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Stack<ulong> stack = new Stack<ulong>();
            stack.Push(1);
            stack.Push(1);
            for (int i = 2; i < number; i++)
            {
                ulong secNumber = stack.Pop();
                ulong firstNumber = stack.Pop();
                stack.Push(secNumber);
                stack.Push(firstNumber + secNumber);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
