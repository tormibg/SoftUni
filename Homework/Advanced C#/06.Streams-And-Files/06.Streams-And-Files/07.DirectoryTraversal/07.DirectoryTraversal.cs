using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

class DirectoryTraversal
{
    static void Main()
    {
        //string directory = Console.ReadLine();
        string directory = @"c:\windows";
        string[] files = Directory.GetFiles(directory).ToArray();
        string getDesktop = Environment.GetEnvironmentVariable("USERPROFILE")+@"\desktop\";

        FunctWay(files, getDesktop);
        Console.WriteLine();
        MetodWay(files, getDesktop);
    }

    private static void FunctWay(string[] files, string getDesktop)
    {
        var fNames = from file in files
                     orderby Path.GetExtension(file) ascending
                     group file by Path.GetExtension(file)
                         into fileGroup
                         orderby fileGroup.Count() descending
                         select fileGroup;

        StreamWriter fsWriter = new StreamWriter(getDesktop + @"\report.txt");
        using (fsWriter)
        {
            foreach (var sortedFile in fNames)
            {
                Console.WriteLine(sortedFile.Key);
                fsWriter.WriteLine(sortedFile.Key);
                var fl = from file in sortedFile orderby new FileInfo(file).Length select file;

                foreach (var fileta in fl)
                {
                    Console.WriteLine("--{0} - {1:F3}kb", new FileInfo(fileta).Name,
                        new FileInfo(fileta).Length/(float) 1024);
                    fsWriter.WriteLine("--{0} - {1:F3}kb", new FileInfo(fileta).Name,
                        new FileInfo(fileta).Length/(float) 1024);
                }
            }
        }
    }

    private static void MetodWay(string[] files, string getDesktop)
    {
        var filNames =
            files.OrderBy(x => new FileInfo(x).Length)
                .GroupBy(x => Path.GetExtension(x))
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key);
        StreamWriter fsWriter = new StreamWriter(getDesktop + @"\report.txt");
        using (fsWriter)
        {
            foreach (var filName in filNames)
            {
                Console.WriteLine(filName.Key);
                fsWriter.WriteLine(filName.Key);
                foreach (var vari in filName)
                {
                    Console.WriteLine("--{0} - {1:F3}kb", new FileInfo(vari).Name,
                        new FileInfo(vari).Length/(float) 1024);
                    fsWriter.WriteLine("--{0} - {1:F3}kb", new FileInfo(vari).Name,
                        new FileInfo(vari).Length/(float) 1024);
                }
            }
        }
    }
}