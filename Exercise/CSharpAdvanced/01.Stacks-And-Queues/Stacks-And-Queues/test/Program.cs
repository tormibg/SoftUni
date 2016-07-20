namespace _11.Poison
{
    using System;
    using System.Collections.Generic;

    public static class PoisonousPlants
    {
        public static void Main()
        {
            var numberOfPlants = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split();
            var a = new int[numberOfPlants];
            for (int i = 0; i < numberOfPlants; i++)
            {
                a[i] = -int.Parse(input[i]);
            }

            var plantStack = new Stack<Tuple<int, int>>();
            var bestDays = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (plantStack.Count == 0)
                {
                    plantStack.Push(new Tuple<int, int>(a[i], 0));
                }
                else
                {
                    var temp = plantStack.Peek();

                    if (a[i] < temp.Item1)
                    {
                        int sc = 1;
                        bestDays = Math.Max(bestDays, sc);
                        plantStack.Push(new Tuple<int, int>(a[i], sc));
                    }
                    else
                    {
                        var nextPlant = plantStack.Peek();
                        int daysAlive = nextPlant.Item2;
                        while (plantStack.Count > 0 && nextPlant.Item1 <= a[i])
                        {
                            plantStack.Pop();
                            if (plantStack.Count == 0)
                            {
                                break;
                            }

                            daysAlive = Math.Max(daysAlive, nextPlant.Item2);
                            nextPlant = plantStack.Peek();
                        }

                        if (plantStack.Count == 0)
                        {
                            plantStack.Push(new Tuple<int, int>(a[i], 0));
                        }

                        else
                        {
                            plantStack.Push(new Tuple<int, int>(a[i], daysAlive + 1));
                            bestDays = Math.Max(bestDays, daysAlive + 1);
                        }


                    }
                }
            }

            Console.WriteLine(bestDays);
        }
    }
}