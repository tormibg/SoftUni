using System;

class FallingRocks
{
    static void Main()
    {
        string[,] intArray = {
                          { "|", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" },
                          { "|", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "|" },
                          };
        uint points = 0;
        string dwarfPointer = "Y";
        //dwarf row = 15
        int dwarfPosition = 6;
        bool gameOn = true;
        ConsoleKeyInfo keyPressed;
        int speed = 320;
        string achievement = "Novice";
        while (gameOn)
        {
            string[] firstLine = { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };

            Random rnd = new Random();
            int newSimbolCnt = rnd.Next(1, 3);
            for (int cnt = 0; cnt < newSimbolCnt; cnt++)
            {
                int simbolPosition = rnd.Next(1, 13);
                if (firstLine[simbolPosition] != " ")
                {
                    cnt--;
                    continue;
                }
                int simbolValue = rnd.Next(1, 12);
                string simbol = getSimbol(simbolValue);
                firstLine[simbolPosition] = simbol;
            }

            //change row value
            for (int row = 15; row > 0; row--)
            {
                for (int col = 0; col <= 13; col++)
                {
                    intArray[row, col] = intArray[row - 1, col];
                }
            }
            for (int col = 0; col < 14; col++)
            {
                intArray[1, col] = firstLine[col];
            }
            //Get consoleKey
            if (Console.KeyAvailable)
            {
                keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.LeftArrow && (dwarfPosition - 1) >= 1)
                {
                    dwarfPosition--;
                }
                else if (keyPressed.Key == ConsoleKey.RightArrow && (dwarfPosition + 1) <= 12)
                {
                    dwarfPosition++;
                }
            }
            //check dwarf position and end game
            if (intArray[15, dwarfPosition] == " ")
            {
                intArray[15, dwarfPosition] = dwarfPointer;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Game Over\r\nScore: {0}.\r\nSkill Level: {1}", points, achievement);
                break;
            }
            System.Threading.Thread.Sleep(speed);
            Console.Clear();
            //display all
            for (int row = 0; row <= 16; row++)
            {
                for (int col = 0; col < 14; col++)
                {
                    Console.Write("{0,-3}", intArray[row, col]);
                }
                Console.WriteLine();
            }
            points += 10;
            if (points == 500)
            {
                achievement = "Good Job!";
                speed = 280;
            }
            if (points == 1000)
            {
                achievement = "Superior!";
                speed = 230;
            }
            if (points == 1500)
            {
                achievement = "Insane!";
                speed = 150;
            }
            if (points == 3000)
            {
                achievement = "GODLIKE !!!";
                speed = 125;
            }
            Console.Write("Points: {0}  Achievement:{1}", points, achievement);
        }
    }

    private static string getSimbol(int simbolValue)
    {
        string str = "";
        switch (simbolValue)
        {
            case 1: str = "^";
                break;
            case 2: str = "@";
                break;
            case 3: str = "*";
                break;
            case 4: str = "&";
                break;
            case 5: str = "+";
                break;
            case 6: str = "$";
                break;
            case 7: str = "#";
                break;
            case 8: str = "!";
                break;
            case 9: str = ".";
                break;
            case 10: str = ";";
                break;
            case 11: str = "%";
                break;
        }
        return str;
    }
}