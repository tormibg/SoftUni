using System;
using System.Threading;
using System.Collections.Generic;

struct myObject 
{
    public int x;
    public int y;
    public char c;
    public ConsoleColor color;
}
struct myStrObject
{
    public int x;
    public int y;
    public string c;
    public ConsoleColor color;
}
class FallingRocks
{
    static void PrintChar(int x, int y, char c, ConsoleColor color = ConsoleColor.White)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }
    static void PrintStr(int x, int y, string c, ConsoleColor color = ConsoleColor.White)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }
    private static char chGetSymbol(byte x)
    {
        char c = ' ';
        switch (x)
        {  //^, @, *, &, +, %, $, #, !, ., ;, - 
            case 1:
                c = '^';
                break;
            case 2:
                c = '@';
                break;
            case 3:
                c = '*';
                break;
            case 4:
                c = '&';
                break;
            case 5:
                c = '+';
                break;
            case 6:
                c = '%';
                break;
            case 7:
                c = '$';
                break;
            case 8:
                c = '#';
                break;
            case 9:
                c = '!';
                break;
            case 10:
                c = '.';
                break;
            case 11:
                c = ';';
                break;
            case 12:
                c = '-';
                break;
        }
        return c;
    }

    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = 60;
        Console.BufferHeight = Console.WindowHeight = 25;
        int liEndArea = 36, liLiveCount = 5, liSocre = -Console.WindowHeight;
        myStrObject myDwarf = new myStrObject();
        myDwarf.x = (int)Console.WindowWidth/2;
        myDwarf.y = Console.WindowHeight - 1;
        myDwarf.c = "(0)";
        myDwarf.color = ConsoleColor.Yellow;
        List<myObject> objects = new List<myObject>();
        bool gameOn = true;
        while (gameOn)
        {
            bool hitted = false;
            Random rnd = new Random();
            myObject oFalStone = new myObject();
            int liSymCount = rnd.Next(1, 2);
            for (int i = 0; i < liSymCount; i++)
            {
                oFalStone.x = rnd.Next(0, liEndArea - 1);
                oFalStone.c = chGetSymbol((byte)rnd.Next(1, 12));
                oFalStone.y = 0;
                oFalStone.color = ConsoleColor.Cyan;
                objects.Add(oFalStone);

            }
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if(pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (myDwarf.x - 1 > 0)
                    {
                        myDwarf.x = myDwarf.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (myDwarf.x + 3 < liEndArea)
                    myDwarf.x = myDwarf.x + 1;
                }
                else if (pressedKey.Key == ConsoleKey.Escape)
                {
                    gameOn = false;
                }
            }
            List<myObject> NewList = new List<myObject>();
            for (int i = 0; i < objects.Count; i++)
            {
                myObject oldStone = objects[i];
                myObject newStone = new myObject();
                newStone.x = oldStone.x;
                newStone.y = oldStone.y + 1;
                newStone.c = oldStone.c;
                newStone.color = oldStone.color;
                if (newStone.y == myDwarf.y && (newStone.x == myDwarf.x || newStone.x == myDwarf.x + 1 || newStone.x == myDwarf.x + 2))
                {
                    liLiveCount--;
                    hitted = true;
                }
                if (liLiveCount <= 0)
                {
                    PrintStr(12, 10, "GAME OVER !!!", ConsoleColor.Red);
                    PrintStr(12, 12, "Pres [enter] to exit", ConsoleColor.Red);
                    Console.ReadLine();
                    return;
                }
                if (newStone.y < Console.WindowHeight)
                {
                    NewList.Add(newStone);
                }
            }
            objects = NewList;
            Console.Clear();
            if (hitted)
            {
                objects.Clear();
                PrintStr(myDwarf.x, myDwarf.y, "X", ConsoleColor.Red);
            }
            else
            {
                PrintStr(myDwarf.x, myDwarf.y, myDwarf.c, myDwarf.color);
            }
            foreach(myObject car in objects)
            {
                PrintChar(car.x, car.y, car.c, car.color);
            }
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                PrintChar(liEndArea, i, '|', ConsoleColor.White);
            }
            liSocre++;
            PrintStr(40, 4, "Lives : " + liLiveCount, ConsoleColor.White);
            int liTmpScore;
            if (liSocre < 0)
            {
                liTmpScore = 0;
            }
            else
            {
                liTmpScore = liSocre;
            }
            PrintStr(40, 5, "Scores : " + liTmpScore, ConsoleColor.White);
            Thread.Sleep(150);
        }
    }
}