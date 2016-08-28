using System.Text;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Network;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public class GetHelpCommand : Command
    {
        public GetHelpCommand(string input, string[] data, Tester tester, StudentsRepository repository, DowloadManager dowloadManager, IOManager ioManager) : base(input, data, tester, repository, dowloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.DisplayHelp();
        }

        private void DisplayHelp()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{new string('_', 100)}");
            sb.AppendLine($"|{"make directory - mkdir: path ",-98}|");
            sb.AppendLine($"|{"traverse directory - ls: depth ",-98}|");
            sb.AppendLine($"|{"comparing files - cmp: path1 path2",-98}|");
            sb.AppendLine($"|{"change directory - cdRel:relative path",-98}|");
            sb.AppendLine($"|{"change directory - cdAbs:absolute path",-98}|");
            sb.AppendLine($"|{"read students data base - readDb: path",-98}|");
            sb.AppendLine(
                $"|{"filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)",-98}|");
            sb.AppendLine(
                $"|{"order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)",-98}|");
            sb.AppendLine(
                $"|{"download file - download: path of file (saved in current directory)",-98}|");
            sb.AppendLine(
                $"|{"download file asinchronously - downloadAsynch: path of file (save in the current directory)",-98}|");
            sb.AppendLine($"|{"get help – help",-98}|");
            sb.AppendLine($"{new string('_', 100)}");
            sb.AppendLine();
            OutputWriter.WriteMessageOnNewLine(sb.ToString());
        }
    }
}