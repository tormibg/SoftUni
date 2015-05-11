using System;

class Joro
{
    static void Main()
    {
        const sbyte csbWeeks = 52;
        char cLeapYear = Convert.ToChar(Console.ReadLine());
        int ileapYear = 0;
        int iNumHol = int.Parse(Console.ReadLine());
        int iHomeWeek = int.Parse(Console.ReadLine());
        if (cLeapYear == 't')
        {
            ileapYear = 3;
        }
        double JoroPlyas = (iNumHol / 2) + (((csbWeeks) - iHomeWeek) * 2)/3 + iHomeWeek + ileapYear;
        Console.WriteLine(JoroPlyas);
    }
}