using System;
using System.Linq;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.Write("Please, enter a sequence of space-separated integers: ");
            int[] numbers = Console.ReadLine().Trim().Split().Select(s => int.Parse(s)).ToArray();

            Console.WriteLine(GetIndex(numbers));
            
        }
    }

    private static int GetIndex(int[] numbeInts)
    {
        for (int i = 0; i < numbeInts.Length; i++)
        {
            if (IsLargerThanNeighbors(numbeInts, i))
            {
                return i;
            }
        }
        return -1;
    }

    public static bool IsLargerThanNeighbors(int[] nums, int i)
    {
        bool isLarger = false;

        if (i == 0)
        {
            isLarger = nums[i + 1] < nums[i];
        }
        else if (i > 0 && i < nums.Length - 1)
        {
            isLarger = nums[i - 1] < nums[i] && nums[i + 1] < nums[i];
        }
        else
        {
            isLarger = nums[i - 1] < nums[i];
        }

        return isLarger;
    }
}