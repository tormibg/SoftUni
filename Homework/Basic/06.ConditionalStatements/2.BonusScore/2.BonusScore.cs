using System;

class BonusScore
{
    static void Main()
    {
        while (true)
        {
            int liScore;
            Console.Write("Enter score /number between 1 and 9/ : ");
            if (int.TryParse(Console.ReadLine(), out liScore))
            {
                switch (liScore)
                {
                    case 1:
                    case 2:
                    case 3:
                        Console.WriteLine("Bonus score is : {0}", liScore*10);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        Console.WriteLine("Bonus score is : {0}", liScore*100);
                        break;
                    case 7:
                    case 8:
                    case 9:
                        Console.WriteLine("Bonus score is : {0}", liScore*1000);
                        break;
                    default:
                        Console.WriteLine("invalid score");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Only numbers between 1 and 9");
            }
        }

    }
}