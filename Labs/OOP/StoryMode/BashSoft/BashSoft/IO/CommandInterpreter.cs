using System;
using System.Diagnostics;
using System.IO;
using BashSoft.Judge;
using BashSoft.Network;
using BashSoft.Repository;
using BashSoft.Static_data;

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
            string command = data[0].ToLower();

            try
            {
                this.ParseCommand(input, command, data);
            }
            catch (DirectoryNotFoundException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private void ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolder(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelative(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readDB":
                    TryReadDatabaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                case "decoder":
                    //TODO
                    break;
                case "download":
                    TryDownloadRequestedFile(input, data);
                    break;
                case "downloadAsynch":
                    TryDownloadRequestedFileAsync(input, data);
                    break;
                case "drobdb":
                    TryDrobDb(input, data);
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        private void TryDrobDb(string input, string[] data)
        {
            if (data.Length != 1)
            {
                this.DisplayInvalidCommandMessage(input);
                return;
            }
            else
            {
                this._repository.UnloadData();
                OutputWriter.WriteMessageOnNewLine("Database dropped !");
            }
        }

        private void TryDownloadRequestedFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                this._downloadManager.Download(url);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryDownloadRequestedFileAsync(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string url = data[1];
                this._downloadManager.DownloadAsync(url);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                this.TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this._repository.OrderAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this._repository.OrderAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                this.TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this._repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this._repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                this._repository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string userName = data[2];
                this._repository.IsQueryForStudentPossiblе(courseName, userName);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryGetHelp(string input, string[] data)
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine($"|{"make directory - mkdir: path ",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"traverse directory - ls: depth ",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"comparing files - cmp: path1 path2",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"change directory - cdRel:relative path",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"change directory - cdAbs:absolute path",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"read students data base - readDb: path",-98}|");
            OutputWriter.WriteMessageOnNewLine(
                $"|{"filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)",-98}|");
            OutputWriter.WriteMessageOnNewLine(
                $"|{"order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)",-98}|");
            OutputWriter.WriteMessageOnNewLine(
                $"|{"download file - download: path of file (saved in current directory)",-98}|");
            OutputWriter.WriteMessageOnNewLine(
                $"|{"download file asinchronously - downloadAsynch: path of file (save in the current directory)",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"get help – help",-98}|");
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private void TryReadDatabaseFromFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                this._repository.LoadData(fileName);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string absPath = data[1];
                this._inptuOutputManager.ChangeCurrentDirectoryAbsolute(absPath);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryChangePathRelative(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string relPath = data[1];
                this._inptuOutputManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                string firstPath = data[1];
                string secondPath = data[2];

                this._judge.CompareContent(firstPath, secondPath);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryTraverseFolder(string input, string[] data)
        {
            switch (data.Length)
            {
                case 1:
                    this._inptuOutputManager.TraverseDirectory(0);
                    break;
                case 2:
                    int depth;
                    bool hasParsed = int.TryParse(data[1], out depth);
                    if (hasParsed)
                    {
                        this._inptuOutputManager.TraverseDirectory(depth);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                    }
                    break;
                default:
                    this.DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        private void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string folderName = data[1];
                this._inptuOutputManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(Path.Combine(SessionData.currentPath, fileName));
            }
            else
            {
                this.DisplayInvalidCommandMessage(input);
            }
        }

        private void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }
    }
}