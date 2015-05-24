using System;
using System.IO;
using System.Linq;

/* Вв 8-ма задача не е уточнонено дали трябва да се групират заедно всички файлове от директориите или всяка директория си е сама за себе си. По надалу е дадено рекурсивно решение и всяка директория си е сама за себе се. Ако всички директории трябва да се обединятя, просто strig[] files става : string[] files = Directory.GetFiles(d,"*",SearchOption.AllDirectories).ToArray(); , а рекурсията отпада !!*/


internal class FullDirectoryTraversal
{
    private static void Main()
    {
        //string directory = Console.ReadLine();
        //string directory = @"..\..\";
        string directory = Environment.GetEnvironmentVariable("TEMP");
        string getDesktop = Environment.GetEnvironmentVariable("USERPROFILE") + @"\desktop\";
            StreamWriter fsWriter = new StreamWriter(getDesktop + @"\report.txt");
        using (fsWriter)
        {
            DirSearch(directory, fsWriter);
        }
    }

    private static void DirSearch(string sDir, StreamWriter fsWriter)
    {

        try
        {
            foreach (string d in Directory.GetDirectories(sDir))
            {
                string[] files = Directory.GetFiles(d,"*",SearchOption.AllDirectories).ToArray();

                FunctWay(files, fsWriter);
                //Console.WriteLine();
                // MetodWay(files);

                DirSearch(d,fsWriter);
            }
        }
        catch
            (System.Exception excpt)
        {
            Console.WriteLine(excpt.Message);
        }

    }

    private static
        void FunctWay
        (string[] files, StreamWriter fsWriter)
    {
        if (files.Length > 0)
        {
            Console.WriteLine();
            Console.WriteLine(Path.GetDirectoryName(files[0]));
            fsWriter.WriteLine();
            fsWriter.WriteLine(Path.GetDirectoryName(files[0]));
            fsWriter.WriteLine(new string('-',20));
            var fNames = from file in files
                orderby Path.GetExtension(file) ascending
                group file by Path.GetExtension(file)
                into fileGroup
                orderby fileGroup.Count() descending
                select fileGroup;

            //       StreamWriter fsWriter = new StreamWriter(getDesktop + @"\report.txt");
            //       using (fsWriter)
//        {
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
            //       }
        }
    }

    private static
        void MetodWay
        (string[] files, string getDesktop)
    {
        var filNames =
            files.OrderBy(x => new FileInfo(x).Length)
                .GroupBy(x => Path.GetExtension(x))
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key);
//        StreamWriter fsWriter = new StreamWriter(getDesktop + @"\report.txt");
//        using (fsWriter)
//        {
            foreach (var filName in filNames)
            {
                Console.WriteLine(filName.Key);
                //fsWriter.WriteLine(filName.Key);
                foreach (var vari in filName)
                {
                    Console.WriteLine("--{0} - {1:F3}kb", new FileInfo(vari).Name,
                        new FileInfo(vari).Length/(float) 1024);
                    //fsWriter.WriteLine("--{0} - {1:F3}kb", new FileInfo(vari).Name,
                    //    new FileInfo(vari).Length/(float) 1024);
                }
            }
//        }
    }
}