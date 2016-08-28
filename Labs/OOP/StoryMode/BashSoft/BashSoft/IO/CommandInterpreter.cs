using System;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using BashSoft.Judge;
using BashSoft.Network;
using BashSoft.Repository;

namespace BashSoft.IO
{
    public class CommandInterpreter
    {
        private Tester _judge;
        private readonly StudentsRepository _repository;
        private readonly DowloadManager _downloadManager;
        private readonly IOManager _inptuOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, DowloadManager downloadManager,
            IOManager inptuOutputManager)
        {
            this._judge = judge;
            this._repository = repository;
            this._downloadManager = downloadManager;
            this._inptuOutputManager = inptuOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0].ToLower();

            try
            {
                Command command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private Command ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "mkdir":
                    return new CreateDirectoryCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "ls":
                    return new TraverseFolderCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "cdRel":
                    return new ChangePathRelativeCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "cdAbs":
                    return new ChangePathAbsoluteCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "readDB":
                    return new ReadDatabaseFromFileCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "show":
                    return new ShowWantedDataCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "filter":
                    return new FilterAndTakeCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "order":
                    return new OrderAndTakeCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "decoder":
                    //TODO
                    throw new InvalidCommandException(input);
                case "download":
                    return new DownloadRequestedFileCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "downloadAsynch":
                    return new DownloadRequestedFileAsyncCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                case "drobdb":
                    return new DrobDbCommand(input, data, this._judge, this._repository, this._downloadManager, this._inptuOutputManager);
                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}