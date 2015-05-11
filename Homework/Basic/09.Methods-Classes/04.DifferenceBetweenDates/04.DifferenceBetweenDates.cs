using System;
using System.Collections.Generic;
using System.Globalization;

class DifferenceBetweenDates
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            DateTime dStartDate, dEndDate;
            dStartDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
            dEndDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(DaysBetween(dStartDate, dEndDate));
        }
    }

    static int DaysBetween(DateTime startDate, DateTime endDate)
    {
        TimeSpan tsSpan = endDate - startDate;
        return tsSpan.Days;
    }
}
