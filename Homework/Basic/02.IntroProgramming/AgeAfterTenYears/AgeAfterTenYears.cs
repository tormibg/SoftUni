using System;

class AgeAfterTenYears
{
    static void Main()
    {
        bool lbCorAns = true;
        while (lbCorAns)
        {
            Console.Write("Enter your birtdate (DD.MM.YYYY): ");
            DateTime ldtBirthDate;
            if (DateTime.TryParse(Console.ReadLine(), out ldtBirthDate))
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("First embodiment :");
                Console.WriteLine("----------------------------------------------------------");
                int liAge = (DateTime.Now.Year - ldtBirthDate.Year) - Convert.ToInt32(DateTime.Now.Month > ldtBirthDate.Month);
                Console.WriteLine("Your age: {0} years", liAge);
                Console.WriteLine("Your age after ten years : {0}", liAge + 10);
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Second embodiment :");
                Console.WriteLine("----------------------------------------------------------");
                TimeSpan ltsAge = DateTime.Now - ldtBirthDate;
                int liYearNow = (int)(ltsAge.Days / 365.242199);
                Double lcDaysNow = ltsAge.Days % 365.242199;
                Console.WriteLine("Your age: {0} years and {1} days", liYearNow, lcDaysNow.ToString("F"));
                Console.WriteLine("Your age after ten years : {0} and {1} days", liYearNow + 10, lcDaysNow.ToString("F"));
                lbCorAns = false;
            }
            else
            {
                Console.WriteLine("You have entered an invalid date." + Environment.NewLine);
            }
        }
    }
 }