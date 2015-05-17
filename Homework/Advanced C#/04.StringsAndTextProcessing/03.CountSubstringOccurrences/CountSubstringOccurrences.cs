using System;

class CountSubstringOccurrences
{
    static void Main()
    {
        string inputStr = Console.ReadLine().ToLower();
        string searchStr = Console.ReadLine().ToLower();
        int indx = inputStr.IndexOf(searchStr);
        int counter = 0;
        while (indx >= 0 && indx <= inputStr.Length)
        {
            counter++;
            indx = inputStr.IndexOf(searchStr, indx + 1);

        }
        Console.WriteLine(counter);
    }
}