using System;
using System.Linq;

class InsertionSort
{
    private static void Main()
    {
        int[] numbers =
                Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s))
                    .ToArray();
        performInsertionSort(numbers);
        foreach (var number in numbers)
        {
            Console.Write("{0} ",number);
        }
    }
    static int[] performInsertionSort(int[] inputArray)
    {
        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (inputArray[j - 1] > inputArray[j])
                {
                    int temp = inputArray[j - 1];
                    inputArray[j - 1] = inputArray[j];
                    inputArray[j] = temp;
                }
            }
        }
        return inputArray;
    }

}