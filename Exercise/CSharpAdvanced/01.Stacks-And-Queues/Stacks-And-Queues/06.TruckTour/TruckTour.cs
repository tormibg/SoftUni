namespace _06.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            int numberGasStation = int.Parse(Console.ReadLine());
            Queue<Station> stationsQueue = new Queue<Station>();
            for (int i = 0; i < numberGasStation; i++)
            {
                int[] inpInts = Console.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray();
                Station station = new Station
                {
                    Gas = inpInts[0],
                    Distance = inpInts[1]
                };
                stationsQueue.Enqueue(station);
            }

            int gasTank = 0;
            Boolean isFound = false;
            int index;

            while (true)
            {
                Station currStation = stationsQueue.Dequeue();
                gasTank += currStation.Gas;
                stationsQueue.Enqueue(currStation);
                Station firstStation = currStation;

                while (gasTank >= currStation.Distance)
                {
                    gasTank -= currStation.Distance;
                    currStation = stationsQueue.Dequeue();
                    stationsQueue.Enqueue(currStation);
                    gasTank += currStation.Gas;

                    if (firstStation == currStation)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    index = currStation.Id;
                    break;
                }

                gasTank = 0;
            }
            Console.WriteLine(index);
        }
    }

    public class Station
    {
        private static int counter = -1;

        public Station()
        {
            this.Id = System.Threading.Interlocked.Increment(ref counter);
        }

        public int Id { get; }

        public int Distance { get; set; }

        public int Gas { get; set; }
    }

}
