using System;
using System.Linq;

class LinearAndBinarySearch
{
    static void Main()
    {
        int[] numbers =
                Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s))
                    .ToArray();
        int element = int.Parse(Console.ReadLine());

        //int index = LinearSearch(numbers, element);
        performInsertionSort(numbers);
        // Console.WriteLine(Array.BinarySearch(numbers, element));
        //foreach (var number in numbers)
        //{
        //    Console.Write("{0} ",number);
        //}
        //Console.WriteLine();

        int index = BinarySearch(numbers, element);

       // Console.WriteLine(index);
    }

    private static int BinarySearch(int[] numbers, int element)
    {
        int mid;
        int lowBound = 0;
        int highBound = numbers.Count() - 1;
        while (lowBound <= highBound)
        {
            mid = (lowBound + highBound) / 2;
            if (numbers[mid] < element)
            {
                lowBound = mid + 1;
                continue;
            }
            else if (numbers[mid] > element)
            {
                highBound = mid - 1;
                continue;
            }
            else
            {
                return mid;
            }
        }
        return -1;
    }

    private static int LinearSearch(int[] numbers, int element)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (element == numbers[i])
            {
                return i;
            }
        }
        return -1;
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