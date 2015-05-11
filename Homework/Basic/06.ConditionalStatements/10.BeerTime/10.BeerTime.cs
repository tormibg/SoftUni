using System;
using System.Globalization;

class BeerTime
{
    static void Main()
    {
        while (true)
        {
            string lsTimeFormat = "h:mm tt";
            var lvTimeCulture = CultureInfo.InvariantCulture;
            DateTime ldtEntTime;
            DateTime ldtBeerStart = DateTime.ParseExact("1:00 PM", lsTimeFormat, lvTimeCulture);
            DateTime ldtBeerEnd = DateTime.ParseExact("3:00 AM", lsTimeFormat, lvTimeCulture);
            Console.Write("What time is it /hh:mm tt AM/PM): ");
            if (DateTime.TryParseExact(Console.ReadLine(), lsTimeFormat, lvTimeCulture, DateTimeStyles.None, out ldtEntTime))
            {
                if (ldtEntTime >= ldtBeerStart || ldtEntTime < ldtBeerEnd)
                {
                    Console.WriteLine(ldtEntTime.ToString(lsTimeFormat, lvTimeCulture) + " -> Beer time");
                }
                else
                {
                    Console.WriteLine(ldtEntTime.ToString(lsTimeFormat, lvTimeCulture) + " -> non-beer time");
                }
            }
            else
            {
                Console.WriteLine("Invalid time");
            }
        }
    }
}