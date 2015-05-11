﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
struct Dwarf
{
    public int x;
    public int y;
    public string str;
    public ConsoleColor color;
}
struct Rocks
{
    public int x;
    public int y;
    public string c;
    public ConsoleColor color;
}
class FallingRocks
{
    public static Random randomGenerator = new Random();
    public static string[] symbols = { "@", "*", "+", "-", "^", "&", "%", "!", "#", "$", ".", ";", "++", "--", "+++", "---", "^^", "@@", "&&" };
    static void PrintOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.White)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }
    static void PrintRockOnPosition(int x, int y, string c, ConsoleColor color = ConsoleColor.White)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static string GenerateSymb(string[] allSymbols)
    {
        int randomIndex = randomGenerator.Next(allSymbols.Length);
        string randomChar = allSymbols[randomIndex];
        return randomChar;
    }
    static void Main()
    {
        Console.BufferHeight = Console.WindowHeight = 20;
        Console.BufferWidth = Console.WindowWidth = 50;
        int playgroundWidth = 30;
        int livesCount = 5;
        int score = 0;
        String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
        int numColors = colorNames.Length;
        List<Rocks> rocks = new List<Rocks>();

        Dwarf dwarf = new Dwarf();
        dwarf.x = playgroundWidth / 2;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.str = "(O)";
        dwarf.color = ConsoleColor.Blue;

        while (true)
        {
            bool isHit = false;
            {
                Rocks rock = new Rocks();
                rock.x = randomGenerator.Next(0, playgroundWidth);
                rock.y = 0;
                rock.color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorNames[randomGenerator.Next(numColors)]);
                if (rock.color == ConsoleColor.Black)
                {
                    rock.color = ConsoleColor.Green;
                }
                rock.c = GenerateSymb(symbols);
                rocks.Add(rock);
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x - 1 >= 0)
                    {
                        dwarf.x = dwarf.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x + 1 < playgroundWidth)
                    {
                        dwarf.x = dwarf.x + 1;
                    }
                }
            }
            List<Rocks> newRockList = new List<Rocks>();
            for (int i = 0; i < rocks.Count; i++)
            {
                Rocks oldRock = rocks[i];
                Rocks newRock = new Rocks();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.c = oldRock.c;
                newRock.color = oldRock.color;
                if (newRock.x >= dwarf.x && newRock.y == dwarf.y && newRock.x <= dwarf.x + 2)
                {
                    livesCount--;
                    isHit = true;
                    if (livesCount <= 0)
                    {
                        PrintOnPosition(playgroundWidth + 5, 9, "Game Over!", ConsoleColor.Red);
                        Console.ReadLine();
                        return;
                    }
                }
                if (newRock.y != dwarf.y && newRock.x != dwarf.x && newRock.y == Console.WindowHeight)
                {
                    score++;
                }
                if (newRock.y < Console.WindowHeight)
                {
                    newRockList.Add(newRock);
                }
            }
            rocks = newRockList;
            Console.Clear();

            foreach (Rocks rock in rocks)
            {
                PrintRockOnPosition(rock.x, rock.y, rock.c, rock.color);
            }
            if (isHit)
            {
                PrintOnPosition(dwarf.x, dwarf.y, "X", ConsoleColor.Red);
                rocks.Clear();
            }
            else
            {
                PrintOnPosition(dwarf.x, dwarf.y, dwarf.str, dwarf.color);
            }
            PrintOnPosition(playgroundWidth + 5, 5, "Lives: " + livesCount, ConsoleColor.White);
            PrintOnPosition(playgroundWidth + 5, 7, "Score: " + score, ConsoleColor.White);
            Thread.Sleep(150);
        }
    }
}
