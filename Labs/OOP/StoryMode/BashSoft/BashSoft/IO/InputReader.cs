using System;
using BashSoft.Static_data;

namespace BashSoft.IO
{
    public class InputReader
    {
        private const string endCommand = "quit";

        private readonly CommandInterpreter _interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this._interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                string input = Console.ReadLine();
                input = input.Trim();
                if (String.Compare(input, endCommand, StringComparison.Ordinal) == 0)
                {
                    return;
                }
                this._interpreter.InterpredCommand(input);
            }
        }
    }
}
