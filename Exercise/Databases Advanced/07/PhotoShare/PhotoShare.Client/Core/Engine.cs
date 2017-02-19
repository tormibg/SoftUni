using PhotoShare.Client.Interfaces;
using System;
using System.Data.Entity.Validation;


namespace PhotoShare.Client.Core
{
    class Engine : IRunnable
    {
        private readonly ICommandDispatcher commandDispatcher;
        private readonly IReader reader;
        private readonly IWriter writer;

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
                    IExecutable command = this.commandDispatcher.DispatchCommand(commandName, data);
                    string result = command.Execute();
                    command.CommitChanges();
                    this.writer.WriteLine(result);
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }
    }
}
