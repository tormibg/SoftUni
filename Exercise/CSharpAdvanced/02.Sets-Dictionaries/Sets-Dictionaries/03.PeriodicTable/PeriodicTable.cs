namespace _03.PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeriodicTable
    {
        public static void Main()
        {
            int lineNumbers = int.Parse(Console.ReadLine());
            SortedSet<string> inputStr = new SortedSet<string>();
            for (int i = 0; i < lineNumbers; i++)
            {
                string[] tmpStrings = Console.ReadLine().Split();
                foreach (string s in tmpStrings)
                {
                    inputStr.Add(s);
                }
            }
            Console.WriteLine(string.Join(" ",inputStr));
        }
    }
}
