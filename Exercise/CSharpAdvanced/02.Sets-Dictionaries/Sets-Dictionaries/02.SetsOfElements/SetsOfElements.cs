namespace _02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main()
        {
            int[] intputArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> intSet = new HashSet<int>();
            for (int i = 0; i < intputArgs[0]; i++)
            {
                intSet.Add(int.Parse(Console.ReadLine()));
            }
            HashSet<int> duplSet = new HashSet<int>();
            for (int i = 0; i < intputArgs[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (intSet.Contains(number))
                {
                    duplSet.Add(number);
                }
            }
            Console.WriteLine(String.Join(" ",duplSet));
        }
    }
}
