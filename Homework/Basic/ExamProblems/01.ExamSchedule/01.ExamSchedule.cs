using System;
using System.Globalization;
using System.Threading;

class ExamSchedule
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
        
        string startHour = Console.ReadLine();
        startHour = startHour.PadLeft(2, '0');
        
        string startMin = Console.ReadLine();
        startMin = startMin.PadLeft(2, '0');

        string dayPart = Console.ReadLine();
        dayPart = dayPart.ToUpper();

        if (dayPart == "PM")
        {
            startHour = (int.Parse(startHour) + 12).ToString();
            if (startHour == "24")
            {
                startHour = "00";
            }
        }

        string durHour = Console.ReadLine();
        durHour = durHour.PadLeft(2, '0');

        string durtMin = Console.ReadLine();
        durtMin = durtMin.PadLeft(2, '0');
        
        string timeToSpan = "" + startHour + ":" + startMin;
        TimeSpan tStart = TimeSpan.ParseExact(timeToSpan,"g",CultureInfo.InvariantCulture);
        timeToSpan = "" + durHour + ":" + durtMin;
        TimeSpan tDur = TimeSpan.ParseExact(timeToSpan, "g", CultureInfo.InvariantCulture);
        TimeSpan tResult = tStart.Add(tDur);
        DateTime time = DateTime.Today.Add(tResult);
        string displayTime = time.ToString("hh:mm:tt");
        Console.WriteLine(displayTime);
    }
}