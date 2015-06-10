using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SlicingFile
{
    static void Main()
    {
        int parts = 5;
        string sourceFile = @"..\..\Fighter.mpg";
        string destinationDirectory = @"..\..\";
        Slice(sourceFile, destinationDirectory, parts);
        List<string> filesList = Directory.GetFiles(destinationDirectory, "part*.mpg").ToList();
        //List<string> filesList = new List<string>();
        //filesList.Add(@"..\..\part-0.mpg");
        //filesList.Add(@"..\..\part-1.mpg");
        //filesList.Add(@"..\..\part-2.mpg");
        //filesList.Add(@"..\..\part-3.mpg");
        //filesList.Add(@"..\..\part-4.mpg");
        //Assemble(filesList, destinationDirectory);
    }

    private static void Assemble(List<string> filesList, string destinationDirectory)
    {
        if (filesList.Count > 0)
        {
            string fileExt = Path.GetExtension(filesList[0].ToLower());
            FileStream fsWrite = new FileStream(destinationDirectory + "assembled"+fileExt,FileMode.Create,FileAccess.Write);
            using (fsWrite)
            {
                for (int i = 0; i < filesList.Count; i++)
                {
                    FileStream fsRead = new FileStream(filesList[i],FileMode.Open,FileAccess.Read);
                    using (fsRead)
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int bytesRead = fsRead.Read(buffer, 0, buffer.Length);
                            if (bytesRead == 0)
                            {
                                break;
                            }
                            else
                            {
                                fsWrite.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
            }
        }
    }

    private static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        FileStream fsRead = new FileStream(sourceFile, FileMode.Open,FileAccess.Read);
        using (fsRead)
        {
           // long targetLength = fsRead.Length;
            long sizeOfEachFile = (long)Math.Ceiling((double)fsRead.Length / parts);
            //Console.WriteLine(targetLength);
            //Console.WriteLine(sizeOfEachFile);
            for (int i = 0; i < parts; i++)
            {
                //string sFileWoExt = Path.GetFileNameWithoutExtension(sourceFile);
                string extFile = Path.GetExtension(sourceFile);
                FileStream fsWrite = new FileStream(destinationDirectory+"part-"+i.ToString()+extFile,FileMode.Create,FileAccess.Write);
                using (fsWrite)
                {
                    int countBytes = 0;
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        if (countBytes >= sizeOfEachFile)
                        {
                            break;
                        }
                        if (countBytes + buffer.Length >= sizeOfEachFile)
                        {
                            buffer = new byte[sizeOfEachFile-countBytes];
                        }
                        countBytes += buffer.Length;
                        int bytesRead = fsRead.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            fsWrite.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }
    }
}