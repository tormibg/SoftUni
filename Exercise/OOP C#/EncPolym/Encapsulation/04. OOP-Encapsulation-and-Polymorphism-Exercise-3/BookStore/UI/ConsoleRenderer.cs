using System;
using BookStore.Interfaces;

namespace BookStore.UI
{
    public class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        } 
    }
}