using System;

class PlayWithIntDoubleAndString
{
    private static void Main()
    {
        while (true)
        {
            ConsoleKeyInfo lsKey;
            Console.WriteLine("Please choose a type :");
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");
            lsKey = Console.ReadKey(true);
            switch (lsKey.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("Please enter a int : ");
                    int liUsrEnt;
                    if (int.TryParse(Console.ReadLine(), out liUsrEnt))
                    {
                        Console.WriteLine(liUsrEnt + 1);
                    }
                    else
                    {
                        Console.WriteLine("Only int");
                    }
                    break;
                case ConsoleKey.D2:
                    Console.Write("Please enter a double : ");
                    double ldUsrEnt;
                    if (double.TryParse(Console.ReadLine(), out ldUsrEnt))
                    {
                        Console.WriteLine(ldUsrEnt + 1);
                    }
                    else
                    {
                        Console.WriteLine("Only double");
                    }
                    break;
                case ConsoleKey.D3:
                    Console.Write("Please enter a string : ");
                    string lsUsrStr = Console.ReadLine();
                    Console.WriteLine(lsUsrStr + "*");

                    break;
                default:
                    Console.WriteLine("Only digit 1-2-3");
                    break;
            }
        }
    }
}