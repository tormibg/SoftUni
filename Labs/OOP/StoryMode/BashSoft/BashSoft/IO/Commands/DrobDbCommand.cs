using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Network;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public class DrobDbCommand : Command
    {
        public DrobDbCommand(string input, string[] data, Tester tester, StudentsRepository repository, DowloadManager dowloadManager, IOManager ioManager) : base(input, data, tester, repository, dowloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.Repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped !");

        }
    }
}