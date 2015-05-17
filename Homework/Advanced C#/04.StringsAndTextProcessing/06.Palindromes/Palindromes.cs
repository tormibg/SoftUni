using System;
using System.Collections.Generic;

class Palindromes
{
    static void Main()
    {
        string[] inputStr = Console.ReadLine().Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> palindromes = new List<string>();
        for (int i = 0; i < inputStr.Length; i++)
        {
            if (IsPalindrome(inputStr[i]))
            {
                palindromes.Add(inputStr[i]);
            }
        }
        palindromes.Sort();
        Console.WriteLine(string.Join(", ", palindromes));
    }

    private static bool IsPalindrome(string p)
    {
        int min = 0;
        int max = p.Length - 1;
        while (true)
        {
            if (min > max)
            {
                return true;
            }
            char ch1 = p[min];
            char ch2 = p[max];

            if (!ch1.Equals(ch2))
            {
                return false;
            }
            min++;
            max--;
        }
    }
}