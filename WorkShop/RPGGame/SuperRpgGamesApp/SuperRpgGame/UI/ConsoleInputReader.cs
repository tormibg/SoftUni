using System;
using SuperRpgGame.Interfaces;

namespace SuperRpgGame.UI
{
    public class ConsoleInputReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}