using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Network;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public class TraverseFolderCommand : Command
    {
        public TraverseFolderCommand(string input, string[] data, Tester tester, StudentsRepository repository, DowloadManager dowloadManager, IOManager ioManager) : base(input, data, tester, repository, dowloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            switch (this.Data.Length)
            {
                case 1:
                    this.InptuOutputManager.TraverseDirectory(0);
                    break;
                case 2:
                    int depth;
                    bool hasParsed = int.TryParse(this.Data[1], out depth);
                    if (hasParsed)
                    {
                        this.InptuOutputManager.TraverseDirectory(depth);
                    }
                    else
                    {
                        throw new InvalidCommandException(this.Input);
                    }
                    break;
                default:
                    throw new InvalidCommandException(this.Input);
            }
        }
    }
}