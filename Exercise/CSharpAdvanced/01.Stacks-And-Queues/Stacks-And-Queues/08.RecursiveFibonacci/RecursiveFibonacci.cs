namespace _08.RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;

    public class RecursiveFibonacci
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            SortedDictionary<int, ulong> fibNumDictionary = new SortedDictionary<int, ulong>();
            Console.WriteLine(GetFibonacci(number, fibNumDictionary));
        }

        static ulong GetFibonacci(int n, SortedDictionary<int, ulong> fibNumDictionary)
        {
            switch (n)
            {
                case 1:
                case 2:
                    return 1;
                default:
                    if (!fibNumDictionary.ContainsKey(n))
                    {
                        fibNumDictionary[n] = (GetFibonacci(n - 1,fibNumDictionary) + GetFibonacci(n - 2,fibNumDictionary));
                    }
                    return fibNumDictionary[n];
            }
        }
    }
}
