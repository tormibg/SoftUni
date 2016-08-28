using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Network;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public class ReadDatabaseFromFileCommand : Command
    {
        public ReadDatabaseFromFileCommand(string input, string[] data, Tester tester, StudentsRepository repository, DowloadManager dowloadManager, IOManager ioManager) : base(input, data, tester, repository, dowloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileName = this.Data[1];
            this.Repository.LoadData(fileName);
        }
    }
}