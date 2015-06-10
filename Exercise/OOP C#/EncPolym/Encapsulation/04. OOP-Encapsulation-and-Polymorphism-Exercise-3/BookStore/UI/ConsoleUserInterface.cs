using System;
using BookStore.Interfaces;

namespace BookStore.UI
{
    public class ConsoleUserInterface : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        } 
    }
}
