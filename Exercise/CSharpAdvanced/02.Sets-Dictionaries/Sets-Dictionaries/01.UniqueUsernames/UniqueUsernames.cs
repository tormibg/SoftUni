namespace _01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UniqueUsernames
    {
        public static void Main()
        {
            HashSet<string> inputStrSet = new HashSet<string>();
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i < input; i++)
            {
                string inputline = Console.ReadLine();
                inputStrSet.Add(inputline);
            }
            foreach (string s in inputStrSet)
            {
                Console.WriteLine(s);
            }
        }
    }
}
