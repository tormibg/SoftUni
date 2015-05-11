using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

struct Object
{
    public int x;
    public int y;
    public char c;
    public ConsoleColor color;
}
class Program
{
    static void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str); 
    }

    static void Main()
    {
        double speed = 100.0;
        int playfieldWidth = 5;
        int livesCount = 5;
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 30;
        Object userCar = new Object();
        userCar.x = 2;
        userCar.y = Console.WindowHeight - 1;
        userCar.c = '@';
        userCar.color = ConsoleColor.Yellow;
        Random randomGenerator = new Random(); 
        List<Object> objects = new List<Object>();
        while (true)
        {
            speed++;
            bool hitted = false;
            Object newCar = new Object();
            newCar.color = ConsoleColor.Green;
            newCar.x = randomGenerator.Next(0, playfieldWidth);
            newCar.y = 0;
            newCar.c = '#';
            objects.Add(newCar);
            while(Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
              //while (Console.KeyAvailable)
              //  {
              //      Console.ReadKey(true);
              //  }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (userCar.x - 1 >= 0)
                    {
                        userCar.x = userCar.x - 1; 
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (userCar.x + 1 < playfieldWidth)
                    {
                        userCar.x = userCar.x + 1;
                    }
                }
            }
            // move our car
            List<Object> newList = new List<Object>();
            for (int i = 0; i < objects.Count; i++)
            {
                Object oldCar = objects[i];
                Object newwCar = new Object();
                newwCar.x = oldCar.x;
                newwCar.y = oldCar.y + 1;
                newwCar.c = oldCar.c;
                newwCar.color = oldCar.color;
                if (newwCar.y == userCar.y && newwCar.x == userCar.x)
                {
                    speed += 50;
                    livesCount--;
                    hitted = true;
                }
                if (livesCount <= 0)
                {
                    PrintStringOnPosition(8,10,"GAME OVER !!!",ConsoleColor.Red);
                    PrintStringOnPosition(8, 12, "Pres [enter] to exit", ConsoleColor.Red);
                    Console.ReadLine();
                    return;
                }
                if (newwCar.y < Console.WindowHeight)
                {
                    newList.Add(newwCar);
                }
            }
            objects = newList;
            Console.Clear();
            if (hitted)
            {
                objects.Clear();
                PrintOnPosition(userCar.x, userCar.y, 'X', ConsoleColor.Red);
            }
            else
            {
                PrintOnPosition(userCar.x, userCar.y, userCar.c, userCar.color);
            }
            foreach (Object car in objects)
            {
                PrintOnPosition(car.x, car.y, car.c, car.color);
            }
            PrintStringOnPosition(8, 4, "Lives : " + livesCount, ConsoleColor.White);
            PrintStringOnPosition(8, 5, "Speed : " + speed, ConsoleColor.White);
            if (speed > 400)
            {
                speed = 400;
            }
            Thread.Sleep((int)(600 - speed));
        }
    }
}
