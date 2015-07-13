using System;
using SuperRpgGame.Interfaces;

namespace SuperRpgGame.UI
{
    public class ConsoleRenderer : IRenderer
    {

        public void WriteLine(string message, params object[] parameters)
        {
            Console.WriteLine(message, parameters);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}