using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Network;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public class CompareFilesCommand : Command
    {
        public CompareFilesCommand(string input, string[] data, Tester tester, StudentsRepository repository, DowloadManager dowloadManager, IOManager ioManager) : base(input, data, tester, repository, dowloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }
            string firstPath = this.Data[1];
            string secondPath = this.Data[2];

            this.Judge.CompareContent(firstPath, secondPath);
        }
    }
}