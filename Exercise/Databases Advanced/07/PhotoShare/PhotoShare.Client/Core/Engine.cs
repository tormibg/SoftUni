﻿using PhotoShare.Client.Interfaces;
using System;


namespace PhotoShare.Client.Core
{
    class Engine : IRunnable
    {
        private ICommandDispatcher commandDispatcher;
        private IReader reader;
        private IWriter writer;
        public Engine(ICommandDispatcher commandDispatcher, IReader reader, IWriter writer)
        {
            this.commandDispatcher = commandDispatcher;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run(string start)
        {
            this.writer.WriteLine("Program started");
            while (true)
            {
                try
                {
                    string input = reader.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = this.commandDispatcher
                        .DispatchCommand(commandName, data)
                        .Execute();
                    this.writer.WriteLine(result);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }
    }
}
