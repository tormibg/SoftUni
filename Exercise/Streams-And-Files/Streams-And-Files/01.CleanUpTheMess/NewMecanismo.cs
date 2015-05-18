using System;
using Comandos;

namespace VehicleParkSystem2
{
    internal class Mecanismo : IMecanismo
    {
        private exec ex;

        private Mecanismo(exec ex)
        {
            this.ex = ex;
        }

        public Mecanismo() : this(new exec())
        {
        }

        public void Runrunrunrunrun()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null) break;
                commandLine.Trim();
                if (string.IsNullOrEmpty(commandLine))
                    try
                    {
                        var comando = new exec.comando(commandLine);
                        string commandResult = ex.execução(comando);
                        Console.WriteLine(commandResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

            }

        }

    }

}
